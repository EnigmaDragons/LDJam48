using E7.Introloop;
using UnityEngine;

public class VictoryController : MonoBehaviour
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private FloatReference creditsDelayIfVictory;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject creditsObj;
    [SerializeField] private IntroLoopAudioPlayer player;
    [SerializeField] private IntroloopAudio victoryFanfare;
    [SerializeField] private IntroloopAudio creditsMusic;
    [SerializeField] private float victoryFanfareDuration = 13f;

    private void Awake()
    {
        var isVictory = gameState.IsVictory;
        if (isVictory)
        {
            victoryText.SetActive(true);
            player.PlaySelectedMusicLooping(victoryFanfare);
            this.ExecuteAfterDelay(() => player.CrossfadeToMusic(creditsMusic, 2f, 0), victoryFanfareDuration);
            this.ExecuteAfterDelay(BeginCredits, creditsDelayIfVictory);
        }
        else
        {
            player.PlaySelectedMusicLooping(creditsMusic);
            BeginCredits();
        }
    }
    
    private void BeginCredits() => creditsObj.SetActive(true);
}