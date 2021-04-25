using System;
using System.Linq;
using Dialogue.Messages;
using Tags;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    [TextArea] [SerializeField] private string text;
    [SerializeField] private StringReference spyExpression;
    [SerializeField] private TagObject[] tags;
    [SerializeField] private FollowupDialogueData[] followups;
    public string Text => text;
    public TagObject[] Tags => tags.ToArray();
    public FollowupDialogueData[] Followups => followups.ToArray();

    public void Select()
    {
        Message.Publish(new HideStatements());
        Message.Publish(new DialogueOptionSelected(this));
        Message.Publish(new ShowSpyExpression(spyExpression));
    }
}