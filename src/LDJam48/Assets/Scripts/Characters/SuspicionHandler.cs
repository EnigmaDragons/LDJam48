using System;
using System.Collections;
using System.Collections.Generic;
using Tags;
using UnityEngine;

public class SuspicionHandler : OnMessage<DialogueOptionSelected>
{
    [SerializeField] private CurrentConversation conversation;
    [SerializeField] private ConflictDatabase conflictDatabase;
    
    protected override void Execute(DialogueOptionSelected msg)
    {
        var chars = conversation.Current.NonPlayerCharacters;
        var totalPenalty = 0;
        print(chars.Length);
        foreach (var character in chars)
        {
            totalPenalty += GivePenalty(msg, character);
            SaveTags(msg, character);   
        }
        
        Message.Publish(new DialogueOptionResolved(msg.Selection, totalPenalty));
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
        foreach (var dialogTag in dialog.Tags)
        {
            foreach (var characterTag in character.GetLearnedTags())
            {
                var penalty = conflictDatabase.GetPenalty(dialogTag, characterTag);
                totalSuspicion += penalty;
                character.AddSuspicion(conflictDatabase.GetPenalty(dialogTag, characterTag));
                //make sure that we add suspicion only once per dialog option 
                if(penalty > 0) break;
            }
        }

        return totalSuspicion;
    }
}
