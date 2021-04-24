using UnityEngine;

public class CharacterSpeechBubble : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private ProgressiveTextReveal speechBubble;
    [SerializeField] private ScenePositions scenePositions;
    [SerializeField] private CurrentConversation conversation;
    
    private void Awake()
    {
        Log.Info($"{character.CharacterName} speech bubble awake");
        speechBubble.Hide();
        scenePositions.Register(character, speechBubble);
    }

    public void Speak(string option)
    {
        speechBubble.Display(option, conversation.NextSequenceIsOptions, Proceed);
    }

    private void Proceed()
    {
        Message.Publish(new AdvanceConversation());
    }
}