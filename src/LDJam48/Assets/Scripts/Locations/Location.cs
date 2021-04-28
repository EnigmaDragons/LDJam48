using System.Collections.Generic;
using E7.Introloop;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Location : ScriptableObject
{
    [SerializeField] private Sprite locationIcon;
    [SerializeField] private GameObject obj;
    [SerializeField] private Conversation[] conversations;
    [SerializeField] private UnityEvent onFinished;
    [SerializeField] private IntroloopAudio calmMusic;
    [SerializeField] private IntroloopAudio tenseMusic;
    [SerializeField] private IntroloopAudio superTenseMusic;
    [SerializeField] private bool isCheckpoint;

    public bool IsCheckpoint => isCheckpoint;
    public Sprite LocationIcon => locationIcon;
    public GameObject Obj => obj;
    public Conversation[] Conversations => conversations;
    public UnityEvent OnFinished => onFinished;

    public Dictionary<TensionLevel, IntroloopAudio> Music => new Dictionary<TensionLevel, IntroloopAudio>
    {
        {TensionLevel.Calm, calmMusic},
        {TensionLevel.Tense, tenseMusic},
        {TensionLevel.SuperTense, superTenseMusic}
    };
}
