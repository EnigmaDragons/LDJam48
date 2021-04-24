using System.Collections;
using System.Collections.Generic;
using Tags;
using UnityEngine;

public class SuspicionHandler : OnMessage<DialogueOptionSelected>
{
    protected override void Execute(DialogueOptionSelected msg)
    {
        GivePenalty(msg);
        SaveTags(msg);
    }

    private void SaveTags(DialogueOptionSelected msg)
    {
        var dialog = msg.Selection;
        var character = msg.CurrentCharacter;

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
    
    private void GivePenalty(DialogueOptionSelected msg)
    {
        var dialog = msg.Selection;
        var character = msg.CurrentCharacter;

        foreach (var dialogTag in dialog.Tags)
        {
            foreach (var characterTag in character.GetLearnedTags())
            {
                character.AddSuspicion(dialogTag.GetConflictPenalty(characterTag));
                //make sure that we add suspicion only once per dialog option 
                break;
            }
        }
    }
}
