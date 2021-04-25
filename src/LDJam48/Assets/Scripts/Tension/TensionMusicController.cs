
using System.Collections.Generic;
using E7.Introloop;
using UnityEngine;

public class TensionMusicController : OnMessage<GameStateChanged>
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private IntroLoopAudioPlayer player;
    [SerializeField] private IntroloopAudio calmMusic;
    [SerializeField] private IntroloopAudio tenseMusic;
    [SerializeField] private IntroloopAudio superTenseMusic;

    private readonly Dictionary<TensionLevel, IntroloopAudio> _musics = new Dictionary<TensionLevel, IntroloopAudio>();
    
    private void Start()
    {
        _musics[TensionLevel.Calm] = calmMusic;
        _musics[TensionLevel.Tense] = tenseMusic;
        _musics[TensionLevel.SuperTense] = superTenseMusic;
        this.ExecuteAfterTinyDelay(() => player.PlaySelectedMusicLooping(_musics[gameState.TensionLevel]));
    }

    protected override void Execute(GameStateChanged msg)
    {
        player.CrossfadeToMusic(_musics[msg.State.TensionLevel], 0.5f, player.CurrentClipPoint);
    }
}