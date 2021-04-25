using UnityEngine;

public class LocationHandler : OnMessage<AdvanceLocation>
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private float delayBeforeFinishing = 2f;

    private bool _finishTriggered = false;
    
    protected override void Execute(AdvanceLocation msg)
    {
        if (_finishTriggered)
            return;
        
        gameState.AdvanceLocationConversation();
        if (gameState.CurrentLocation.Conversations.Length > gameState.LocationConversationIndex)
            Message.Publish(new StartConversation(gameState.CurrentLocation.Conversations[gameState.LocationConversationIndex]));
        else
        {
            _finishTriggered = true;
            this.ExecuteAfterDelay(() => gameState.CurrentLocation.OnFinished.Invoke(), delayBeforeFinishing);
        }
    }
}
