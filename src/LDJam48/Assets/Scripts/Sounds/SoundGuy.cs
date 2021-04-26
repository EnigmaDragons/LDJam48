using System.Linq;
using UnityEngine;

public class SoundGuy : OnMessage<DialogueOptionResolved>
{
    [SerializeField] private UiSfxPlayer sfx;
    [SerializeField] private AudioClipVolume gainedSus;
    [SerializeField] private AudioClipVolume gainedMuchSus;
    
    protected override void Execute(DialogueOptionResolved msg)
    {
        if (msg.PlayerSuspicionChange.Any(x => x.Value > 3 || x.Key.IsSus()))
            sfx.Play(gainedMuchSus);
        else if (msg.PlayerSuspicionChange.Any(x => x.Value > 0))
            sfx.Play(gainedSus);
    }
}