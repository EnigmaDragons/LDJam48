using UnityEngine;

[CreateAssetMenu(fileName = "CurrentConversation", menuName = "Dialogue/CurrentConversation")]
public class CurrentConversation : ScriptableObject
{
    [SerializeField] private Conversation conversation;

    public Conversation Current => conversation;
    public void Set(Conversation c) => conversation = c;
}