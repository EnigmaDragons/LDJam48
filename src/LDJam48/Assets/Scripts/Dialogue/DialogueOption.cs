using System;
using System.Linq;
using System.Runtime.Serialization;
using Tags;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    [SerializeField] private string text;
    [SerializeField] private TagObject[] tags;

    public string Text => text;
    public TagObject[] Tags => tags.ToArray();

    public void Select()
    {
        Message.Publish(new HideStatements());
        Message.Publish(new DialogueOptionSelected(this,
            (Character) FormatterServices.GetUninitializedObject(typeof(Character))));
    }
}