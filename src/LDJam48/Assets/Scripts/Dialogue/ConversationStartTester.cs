using UnityEngine;

public class ConversationStartTester : MonoBehaviour
{
    [SerializeField] private LinearConversation conversation;

    private void Update()
    {
        if (conversation == null) 
            return;
        
        Message.Publish(new StartConversation(conversation));
        conversation = null;
    }
}