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
        conversation.QueuePlayerLine(msg.Selected.Text);
        msg.Selected.Followups.ForEachArr(followup =>
        {
            var c = followup.SpeakingCharacter;
            var susAmount = msg.PlayerSuspicionChange.TryGetValue(c, out var susChange) ? susChange : 0;
            if (followup.ShouldShow(c, susAmount))
                conversation.Queue(followup.AsArray());
        });
        StartNext();
    }
    
    private void StartNext() => conversation.ExecuteNext();
}