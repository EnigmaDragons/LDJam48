using System.Linq;
using UnityEngine;

public class ConversationHandler : OnMessage<StartConversation, AdvanceConversation, DialogueOptionResolved>
{
    [SerializeField] private CurrentConversation conversation;
    
    protected override void Execute(StartConversation msg)
    {
        conversation.Set(msg.Conversation);
        conversation.ExecuteNext();
    }

    protected override void Execute(AdvanceConversation msg) => StartNext();
    protected override void Execute(DialogueOptionResolved msg)
    {
        var gainedSuspicion = msg.PlayerSuspicionChange > 0;
        conversation.QueuePlayerLine(msg.Selected.Text);
        conversation.Queue(msg.Selected.Followups.Where(x => x.OnlyShowIfCharacterLikedAnswer != gainedSuspicion).ToArray());
        StartNext();
    }
    
    private void StartNext() => conversation.ExecuteNext();
}