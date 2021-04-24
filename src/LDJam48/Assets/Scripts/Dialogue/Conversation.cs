using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Conversation", menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private Character[] nonPlayerCharacters;
    [SerializeField] private UnityEvent onFinished;
    [SerializeField] private DialogueData[] sequence;

    public UnityEvent OnFinished => onFinished;
    public Character[] NonPlayerCharacters => nonPlayerCharacters;
    public DialogueData[] Sequence => sequence.ToArray();

    private void OnValidate()
    {
        CheckIfIdentical();
    }

    private void CheckIfIdentical()
    {
        var chars = new List<Character>();

        foreach (var character in nonPlayerCharacters)
        {
            if (chars.Contains(character))
            {
                throw new Exception($"All characters in conversation {name} must be unique");
            }
            chars.Add(character);
        }
    }
}
