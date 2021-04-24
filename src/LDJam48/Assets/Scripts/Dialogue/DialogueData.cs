using System;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [SerializeField] private Character speakingCharacter;
    [SerializeField] private string statement;
    [SerializeField] private DialogueOption[] options;

    public void Begin()
    {
        if (!string.IsNullOrWhiteSpace(statement))
            Message.Publish(new ShowStatement(speakingCharacter, statement));
    }
}