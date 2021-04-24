using UnityEngine;

public class FixedPositionStatementDisplay : OnMessage<ShowStatement, HideStatements>
{
    [SerializeField] private ProgressiveTextReveal text;
    
    protected override void Execute(ShowStatement msg)
    {
        text.Display(msg.Statement, () => Message.Publish(new AdvanceConversation()));
    }

    protected override void Execute(HideStatements msg) => text.Hide();
}
