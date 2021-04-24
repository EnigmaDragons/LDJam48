using System;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    [SerializeField] private string text;

    public string Text => text;
}