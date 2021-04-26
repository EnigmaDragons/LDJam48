using System.Linq;
using UnityEngine;

public class GameOverHandler : OnMessage<DialogueOptionResolved>
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private CurrentConversation conversation;
    [SerializeField] private Navigator navigator;
    [SerializeField] private float delayBeforeScene;
    
    protected override void Execute(DialogueOptionResolved msg)
    {
        var gameOverCharacters = msg.PlayerSuspicionChange.Where(x => x.Key.GetSuspicion() >= x.Key.GetMaxSuspicion()).ToList();
        if (!gameOverCharacters.Any()) return;
        
        var followupLines = gameOverCharacters.SelectMany(c => c.Key.CoverBlownLines).ToArray();
        gameState.UpdateState(g => g.IsDefeat = true);
        conversation.Override(followupLines, () => this.ExecuteAfterDelay(navigator.NavigateToGameOver, delayBeforeScene));
    }
}
