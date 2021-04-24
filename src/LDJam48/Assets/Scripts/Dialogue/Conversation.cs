using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private Character[] nonPlayerCharacters;
    [SerializeField] private DialogueData[] sequence;

    public Character[] NonPlayerCharacters => nonPlayerCharacters;
    public DialogueData[] Sequence => sequence.ToArray();
}
