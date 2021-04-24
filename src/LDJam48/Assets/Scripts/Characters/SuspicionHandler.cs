using System;
using System.Collections;
using System.Collections.Generic;
using Tags;
using UnityEngine;

public class SuspicionHandler : OnMessage<DialogueOptionSelected>
{
    [SerializeField] private CurrentConversation conversation;
    
    protected override void Execute(DialogueOptionSelected msg)
    {
        var chars = conversation.Current.NonPlayerCharacters;
        print(chars.Length);
        foreach (var character in chars)
        {
            GivePenalty(msg, character);
            SaveTags(msg, character);   
        }
        
        Message.Publish(new Finished<DialogueOptionSelected>{ Message = msg });
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
                if(dialogTag.Conflicts(characterTag)) shouldLearn = false;
                if(characterTag == dialogTag) shouldLearn = false;
            }
            if(shouldLearn) toLearn.Add(dialogTag);
        }

        character.LearnTags(toLearn);
    }
    
    private void GivePenalty(DialogueOptionSelected msg, Character character)
    {
        var dialog = msg.Selection;

        foreach (var dialogTag in dialog.Tags)
        {
            foreach (var characterTag in character.GetLearnedTags())
            {
                var penalty = dialogTag.GetConflictPenalty(characterTag);
                character.AddSuspicion(dialogTag.GetConflictPenalty(characterTag));
                //make sure that we add suspicion only once per dialog option 
                if(penalty > 0) break;
            }
        }
    }
}
