using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [SerializeField] private Character speakingCharacter;
    [TextArea][SerializeField] public string statement;
    [SerializeField] private StringReference statementEmotion = new StringReference("Default");
    [SerializeField] public DialogueOption[] options;

    public bool IsDialogueOptions => string.IsNullOrWhiteSpace(statement) && options.Any();
    
    public void Begin()
    {
        if (!string.IsNullOrWhiteSpace(statement))
            Message.Publish(new ShowStatement(speakingCharacter, statement, statementEmotion));
        else if (options.Any())
            Message.Publish(new ShowDialogueOptions(options));
    }
}