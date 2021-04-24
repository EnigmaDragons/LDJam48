using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class LinearConversation : ScriptableObject
{
    [SerializeField] private DialogueData[] sequence;

    public DialogueData[] Sequence => sequence.ToArray();
}
