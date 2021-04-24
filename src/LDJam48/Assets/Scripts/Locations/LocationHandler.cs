using UnityEngine;

public class LocationHandler : OnMessage<AdvanceLocation>
{
    [SerializeField] private CurrentGameState gameState;
    
    protected override void Execute(AdvanceLocation msg)
    {
        gameState.AdvanceLocationConversation();
        if (gameState.CurrentLocation.Conversations.Length > gameState.LocationConversationIndex)
            Message.Publish(new StartConversation(gameState.CurrentLocation.Conversations[gameState.LocationConversationIndex]));
        else
            gameState.CurrentLocation.OnFinished.Invoke();
    }
}
