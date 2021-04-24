using UnityEngine;

public class FixedPositionStatementDisplay : OnMessage<ShowStatement, HideStatements>
{
    [SerializeField] private ProgressiveTextReveal text;
    [SerializeField] private CurrentConversation conversation;
    
    protected override void Execute(ShowStatement msg)
    {
        text.Display(msg.Statement, conversation.NextSequenceIsOptions,() => Message.Publish(new AdvanceConversation()));
    }

    protected override void Execute(HideStatements msg) => text.Hide();
}
