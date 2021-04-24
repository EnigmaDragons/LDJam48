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
        if (conversation.Current.Sequence.Length > _sequenceIndex)
            conversation.Current.Sequence[_sequenceIndex].Begin();
        else
            Message.Publish(new ConversationFinished());
    }

    protected override void Execute(AdvanceConversation msg)
    {
        _sequenceIndex++;
        BeginSequence();
    }
}