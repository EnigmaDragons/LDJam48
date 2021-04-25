using System.Linq;
using UnityEngine;

public class GameOverHandler : OnMessage<DialogueOptionResolved>
{
    [SerializeField] private Navigator navigator;
    [SerializeField] private float delayBeforeScene;
    
    protected override void Execute(DialogueOptionResolved msg)
    {
        if (msg.PlayerSuspicionChange.Any(x => x.Key.GetSuspicion() >= x.Key.GetMaxSuspicion()))
            this.ExecuteAfterDelay(() => navigator.NavigateToGameOver(), delayBeforeScene);
    }
}
