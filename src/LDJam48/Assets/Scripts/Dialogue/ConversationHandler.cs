
public class ConversationHandler : OnMessage<StartConversation, AdvanceConversation>
{
    private LinearConversation _current;
    private int _sequenceIndex = 0;

    protected override void Execute(StartConversation msg)
    {
        _current = msg.Conversation;
        _sequenceIndex = 0;
        BeginNext();
    }

    private void BeginNext()
    {
        if (_current.Sequence.Length > _sequenceIndex)
            _current.Sequence[_sequenceIndex].Begin();
        else
            Message.Publish(new ConversationFinished());
    }

    protected override void Execute(AdvanceConversation msg)
    {
        _sequenceIndex++;
        BeginNext();
    }
}