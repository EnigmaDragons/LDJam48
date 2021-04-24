using Dialogue.Messages;
using UnityEngine;

public class ConversationStartTester : MonoBehaviour
{
    [SerializeField] private Conversation conversation;

    private void Update()
    {
        if (conversation == null) 
            return;
        
        StartConversation();
        conversation = null;
    }

    private void StartConversation()
    {
        Message.Publish( new SpawnCharacters(conversation.NonPlayerCharacters));
        Message.Publish(new StartConversation(conversation));
    }
}