using UnityEngine;

public class CharacterSpeechBubble : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private ProgressiveTextReveal speechBubble;
    [SerializeField] private ScenePositions scenePositions;
    
    private void Awake()
    {
        Log.Info($"{character.CharacterName} speech bubble awake");
        speechBubble.Hide();
        scenePositions.Register(character, speechBubble);
    }

    public void Speak(DialogueOption option)
    {
        speechBubble.Display(option.Text);    
    }
}