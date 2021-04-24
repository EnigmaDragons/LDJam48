using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Conversation", menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private Character[] nonPlayerCharacters;
    [SerializeField] private UnityEvent onFinished;
    [SerializeField] private DialogueData[] sequence;

    public UnityEvent OnFinished => onFinished;
    public Character[] NonPlayerCharacters => nonPlayerCharacters;
    public DialogueData[] Sequence => sequence.ToArray();
}
