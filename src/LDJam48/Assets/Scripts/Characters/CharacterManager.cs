using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterSpeechBubble speechBubble;
    
    
    //TODO implement speak method
    public void Speak(string option)
    {
        speechBubble.Speak(option);
    }

    public void HideSpeech() => speechBubble.Hide();
}