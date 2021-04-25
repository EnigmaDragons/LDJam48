using System.Collections.Generic;
using System.Linq;
using Tags;
using UnityEngine;

public class SuspicionHandler : OnMessage<DialogueOptionSelected>
{
    [SerializeField] private CurrentConversation conversation;
    [SerializeField] private ConflictDatabase conflictDatabase;
    
    protected override void Execute(DialogueOptionSelected msg)
    {
        var chars = conversation.Current.NonPlayerCharacters;
        var charSusChanges = new Dictionary<Character, int>();
        foreach (var character in chars)
        {
            charSusChanges[character] = GivePenalty(msg, character);
            SaveTags(msg, character);
        }
        charSusChanges[conversation.Current.PlayerCharacter] = charSusChanges.Max(x => x.Value);
        
        Message.Publish(new DialogueOptionResolved(msg.Selection, charSusChanges));
    }
    
    private void SaveTags(DialogueOptionSelected msg, Character character)
    {
        var dialog = msg.Selection;

        var toLearn = new List<TagObject>();
        foreach (var dialogTag in dialog.Tags)
        {
            var shouldLearn = true;
            foreach (var characterTag in character.GetLearnedTags())
            {
                if(conflictDatabase.Conflicts(dialogTag, characterTag)) shouldLearn = false;
                if(characterTag == dialogTag) shouldLearn = false;
            }
            if(shouldLearn) toLearn.Add(dialogTag);
        }

        character.LearnTags(toLearn);
    }
    
    private int GivePenalty(DialogueOptionSelected msg, Character character)
    {
        var dialog = msg.Selection;
        var totalSuspicion = 0;
        var tagMatchesWithExistingStory = new List<TagObject>();
        foreach (var dialogTag in dialog.Tags)
        {
            foreach (var characterTag in character.GetLearnedTags())
            {
                // Track Congruent Cover Story
                if (characterTag == dialogTag)
                    tagMatchesWithExistingStory.Add(characterTag);
                
                var penaltyAmount = conflictDatabase.GetPenalty(dialogTag, characterTag);
                totalSuspicion += penaltyAmount;
                //make sure that we add suspicion only once per dialog option
                if(penaltyAmount > 0) break;
            }
        }

        if (tagMatchesWithExistingStory.Any())
            Log.Info($"Matches existing story: {string.Join(",",tagMatchesWithExistingStory.Select(x => x.GetName()))}");
        if (totalSuspicion > 0)
            Log.Info($"Gained {totalSuspicion} Suspicion from {character.CharacterName}");

        var finalSusAmount = tagMatchesWithExistingStory.Any() && totalSuspicion <= 0
            ? -1 // Bonus for being congruent with existing Cover Story
            : totalSuspicion;
        character.AddSuspicion(finalSusAmount);
        return finalSusAmount;
    }
}
