using System;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [SerializeField] private Character speakingCharacter;
    [SerializeField] private string statement;
    [SerializeField] private DialogueOption[] options;
}