using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue.Messages;
using UnityEngine;

public class NPCManager : OnMessage<SpawnCharacters, ShowStatement>
{
    [SerializeField] private NPCSpawner spawner;
    
    protected override void Execute(SpawnCharacters msg)
    {
        SpawnCharacters(msg.NPCs, msg.PlayerCharacter);
    }

    protected override void Execute(ShowStatement msg)
    {
        ShowDialogue(msg.SpeakingCharacter, msg.Statement);
    }

    private void SpawnCharacters(Character[] NPCs, Character playerCharacter)
    {
        foreach (var character in NPCs)
        {
            spawner.SpawnCharacter(character);
        }
        
        spawner.SpawnPlayerCharacter(playerCharacter);
    }

    private void ShowDialogue(Character speaker, string dialogue)
    {
        var manager = spawner.GetCharacterManager(speaker);
        if (manager == null) throw new Exception($"Character {speaker.CharacterName} is not currently on the scene");
        
        manager.Speak(dialogue);
    }
}