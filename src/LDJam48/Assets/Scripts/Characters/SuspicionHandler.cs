using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionHandler : OnMessage<DialogueOptionSelected>
{
    protected override void Execute(DialogueOptionSelected msg)
    {
        GivePenalty(msg);    
    }

    private void SaveTags(DialogueOptionSelected msg)
    {
        
    }
    
    private void GivePenalty(DialogueOptionSelected msg)
    {
        var dialog = msg.Selection;
        var character = msg.CurrentCharacter;

        foreach (var dialogTag in dialog.Tags)
        {
            foreach (var characterTag in character.learnedTags)
            {
                character.AddSuspicion(dialogTag.GetConflictPenalty(characterTag));
            }
        }
    }
}
