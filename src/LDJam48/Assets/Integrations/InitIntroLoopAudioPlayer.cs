using UnityEngine;

public class InitIntroLoopAudioPlayer : CrossSceneSingleInstance
{
    [SerializeField] private IntroLoopAudioPlayer player;
    
    protected override string UniqueTag => "Music";
    
    private void Start() => player.Init();
}

