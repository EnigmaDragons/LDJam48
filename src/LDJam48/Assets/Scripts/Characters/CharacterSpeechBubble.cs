using UnityEngine;

public class CharacterSpeechBubble : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private ProgressiveTextReveal speechBubble;
    [SerializeField] private ScenePositions scenePositions;
    [SerializeField] private CurrentConversation conversation;
    [SerializeField] private CharacterNameLabel nameLabel;
    [SerializeField] private bool speechBubbleIsToTheLeftOfTheCharacter = true;
    
    private void Awake()
    {
        Log.Info($"{character.CharacterName} speech bubble awake");
        speechBubble.Hide();
        scenePositions.Register(character, speechBubble);
        nameLabel.Init(character.CharacterName);
        if (!speechBubbleIsToTheLeftOfTheCharacter)
            speechBubble.ReversePanelFacing();
    }

    public void Speak(string option)
    {
        speechBubble.Display(option, conversation.NextSequenceIsOptions, !conversation.NextSequenceIsOptions, Proceed);
    }

    public void Hide() => speechBubble.Hide();

    private void Proceed()
    {
        Message.Publish(new AdvanceConversation());
    }
}