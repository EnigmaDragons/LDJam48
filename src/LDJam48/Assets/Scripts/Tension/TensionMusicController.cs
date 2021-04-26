
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

    private readonly Dictionary<TensionLevel, IntroloopAudio> _defaultMusics = new Dictionary<TensionLevel, IntroloopAudio>();
    private Dictionary<TensionLevel, IntroloopAudio> _locationMusics = new Dictionary<TensionLevel, IntroloopAudio>();
    
    private void Start()
    {
        _defaultMusics[TensionLevel.Calm] = calmMusic;
        _defaultMusics[TensionLevel.Tense] = tenseMusic;
        _defaultMusics[TensionLevel.SuperTense] = superTenseMusic;
        _locationMusics = gameState.CurrentLocation.Music;
        this.ExecuteAfterTinyDelay(() => player.PlaySelectedMusicLooping(GetCurrentMusic(gameState.TensionLevel)));
    }

    protected override void Execute(GameStateChanged msg)
    {
        player.CrossfadeToMusic(GetCurrentMusic(msg.State.TensionLevel), 0.5f, player.CurrentClipPoint);
    }

    private IntroloopAudio GetCurrentMusic(TensionLevel t)
    {
        _locationMusics = gameState.CurrentLocation.Music;
        var newMusic = _defaultMusics[t];
        if (_locationMusics.ContainsKey(t))
        {
            if (_locationMusics[t] != null)
                newMusic = _locationMusics[t];
        }
        return newMusic;
    }
}