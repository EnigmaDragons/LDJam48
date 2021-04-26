using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Location : ScriptableObject
{
    [SerializeField] private Sprite locationIcon;
    [SerializeField] private GameObject obj;
    [SerializeField] private Conversation[] conversations;
    [SerializeField] private UnityEvent onFinished;

    public Sprite LocationIcon => locationIcon;
    public GameObject Obj => obj;
    public Conversation[] Conversations => conversations;
    public UnityEvent OnFinished => onFinished;
}
