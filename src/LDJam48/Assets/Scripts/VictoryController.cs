using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private FloatReference creditsDelayIfVictory;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject creditsObj;

    private void Awake()
    {
        var isVictory = gameState.IsVictory;
        if (isVictory)
        {
            victoryText.SetActive(true);
            this.ExecuteAfterDelay(BeginCredits, creditsDelayIfVictory);
        }
        else
        {
            BeginCredits();
        }
    }
    
    private void BeginCredits() => creditsObj.SetActive(true);
}