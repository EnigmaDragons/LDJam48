using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [SerializeField] private Character speakingCharacter;
    [SerializeField] private string statement;
    [SerializeField] private DialogueOption[] options;

    public bool IsDialogueOptions => string.IsNullOrWhiteSpace(statement) && options.Any();
    
    public void Begin()
    {
        if (!string.IsNullOrWhiteSpace(statement))
            Message.Publish(new ShowStatement(speakingCharacter, statement));
        else if (options.Any())
            Message.Publish(new ShowDialogueOptions(options));
    }
}