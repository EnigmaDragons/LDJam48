using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue.Messages;
using UnityEngine;

public class NPCManager : OnMessage<SpawnCharacters>
{
    [SerializeField] private NPCSpawner spawner;

    public void CharacterSpeak(Character character, DialogueOption option)
    {
        var manager = spawner.GetCharacterManager(character);
        manager.Speak(option);
    }

    protected override void Execute(SpawnCharacters msg)
    {
        SpawnCharacters(msg.ToSpawn);
    }

    private void SpawnCharacters(Character[] toSpawn)
    {
        foreach (var character in toSpawn)
        {
            spawner.SpawnCharacter(character);
        }
    }

    private void ShowDialogue(Character speaker, DialogueOption dialogue)
    {
        var manager = spawner.GetCharacterManager(speaker);
        if (manager == null) throw new Exception($"Character {speaker.CharacterName} is not currently on the scene");

        manager.Speak(dialogue);
    }
}
