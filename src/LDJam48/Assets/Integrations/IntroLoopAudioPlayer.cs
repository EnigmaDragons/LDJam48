using E7.Introloop;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class IntroLoopAudioPlayer : ScriptableObject
{
    [SerializeField] private IntroloopAudio currentClip;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string volumeValueName = "MusicVolume";
    [SerializeField] private FloatReference reductionDb = new FloatReference(0f);
    [SerializeField] private bool debugLoggingEnabled = true;

    public void Init()
    {
        
        if(debugLoggingEnabled)
            Log.Info("Init Introloop Player");    
        IntroloopPlayer.Instance.SetMixerGroup(mixer.FindMatchingGroups(volumeValueName)[0]);
        currentClip = null;
    }
    
    public void PlaySelectedMusicLooping(IntroloopAudio clipToPlay)
    {
        if (currentClip != null && currentClip.name == clipToPlay.name) return;
        
        Log.Info("Play Introloop Music");  
        
        currentClip = clipToPlay;
        IntroloopPlayer.Instance.Play(clipToPlay);

        var volume = PlayerPrefs.GetFloat(volumeValueName, 0.5f);
        var mixerVolume = (Mathf.Log10(volume) * 20) - reductionDb;
        Debug.Log($"Init - Set Audio Level for {volumeValueName} to {volume} ({mixerVolume}db)");
        mixer.SetFloat(volumeValueName, mixerVolume);
    }
}
