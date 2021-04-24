using UnityEngine;

public class ConversationHandler : OnMessage<StartConversation, AdvanceConversation>
{
    [SerializeField] private CurrentConversation conversation;
    
    private int _sequenceIndex = 0;

    protected override void Execute(StartConversation msg)
    {
        conversation.Set(msg.Conversation);
        _sequenceIndex = 0;
        BeginSequence();
    }

    private void BeginSequence()
    {
        var c = conversation.Current;
        if (c.Sequence.Length > _sequenceIndex)
            c.Sequence[_sequenceIndex].Begin();
        else
            c.OnFinished.Invoke();
    }

    protected override void Execute(AdvanceConversation msg)
    {
        _sequenceIndex++;
        BeginSequence();
    }
}