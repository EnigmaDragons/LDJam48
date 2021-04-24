using System;
using System.Linq;
using Tags;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    [SerializeField] private string text;
    [SerializeField] private TagObject[] tags;

    public string Text => text;
    public TagObject[] Tags => tags.ToArray();
}