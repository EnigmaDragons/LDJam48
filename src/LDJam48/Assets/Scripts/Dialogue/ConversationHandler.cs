using UnityEngine;

public class ConversationHandler : OnMessage<StartConversation, AdvanceConversation, Finished<DialogueOptionSelected>>
{
    [SerializeField] private CurrentConversation conversation;
    
    protected override void Execute(StartConversation msg)
    {
        conversation.Set(msg.Conversation);
        conversation.ExecuteNext();
    }

    protected override void Execute(AdvanceConversation msg) => StartNext();
    protected override void Execute(Finished<DialogueOptionSelected> msg)
    {
        conversation.Queue(msg.Message.Selection.Followups);
        StartNext();
    }

    private void StartNext() => conversation.ExecuteNext();
}