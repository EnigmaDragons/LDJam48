using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterSpeechBubble speechBubble;
    //TODO implement speak method
    public void Speak(DialogueOption option)
    {
        speechBubble.Speak(option);
    }
}
