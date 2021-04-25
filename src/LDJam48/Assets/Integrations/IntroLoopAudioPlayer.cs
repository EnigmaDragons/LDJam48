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

    private string _clipName = "";

    public float CurrentClipPoint => IntroloopPlayer.Instance.GetPlayheadTime();
    
    public void Init()
    {
        if(debugLoggingEnabled)
            Log.Info("Init Introloop Player");    
        IntroloopPlayer.Instance.SetMixerGroup(mixer.FindMatchingGroups(volumeValueName)[0]);
        currentClip = null;
        _clipName = "";
    }
    
    public void PlaySelectedMusicLooping(IntroloopAudio clipToPlay)
    {
        if (currentClip != null && clipToPlay.name.Equals(_clipName)) 
            return;
        if (debugLoggingEnabled)
            Log.Info($"Play Introloop Music {clipToPlay.name}");
        UpdateVolume();

        currentClip = clipToPlay;
        _clipName = clipToPlay.name;
        IntroloopPlayer.Instance.Play(clipToPlay);
    }

    private void UpdateVolume()
    {
        var volume = PlayerPrefs.GetFloat(volumeValueName, 0.5f);
        var mixerVolume = (Mathf.Log10(volume) * 20) - reductionDb;
        mixer.SetFloat(volumeValueName, mixerVolume);
    }

    public void CrossfadeToMusic(IntroloopAudio clipToPlay, float crossfadeDuration, float startPoint)
    {
        if (currentClip != null && clipToPlay.name.Equals(_clipName)) 
            return;
        if (debugLoggingEnabled)
            Log.Info($"Crossfade Introloop Music {clipToPlay.name}");
        UpdateVolume();
        
        currentClip = clipToPlay;
        _clipName = clipToPlay.name;
        IntroloopPlayer.Instance.Play(clipToPlay, crossfadeDuration, startPoint);
    }
}
