using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private NPCSpawner spawner;

    public void CharacterSpeak(Character character, DialogueOption option)
    {
        var manager = spawner.GetCharacterManager(character);
        manager.Speak(option);
    }
}
