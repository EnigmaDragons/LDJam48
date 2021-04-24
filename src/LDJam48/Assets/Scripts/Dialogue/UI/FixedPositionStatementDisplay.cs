using UnityEngine;

public class FixedPositionStatementDisplay : OnMessage<ShowStatement>
{
    [SerializeField] private ProgressiveTextReveal text;
    
    protected override void Execute(ShowStatement msg)
    {
        text.Display(msg.Statement, () => Message.Publish(new AdvanceConversation()));
    }
}
