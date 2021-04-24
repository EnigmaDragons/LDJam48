using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : OnMessage<StartConversation>
{
    [SerializeField] private Transform[] spawnPositions;
    private List<Character> _charactersOnScene = new List<Character>();
    private Dictionary<Character, CharacterManager> _managers = new Dictionary<Character, CharacterManager>();
    protected override void Execute(StartConversation msg)
    {
        foreach (var character in msg.Conversation.NonPlayerCharacters)
        {
            SpawnCharacter(character);
        }
    }

    public CharacterManager GetCharacterManager(Character character)
    {
        if (!_charactersOnScene.Contains(character)) return null;

        return _managers[character];
    }
    
    
    //TODO make characters play entrance animation instead of just spawning in
    public void SpawnCharacter(Character character)
    {
        var id = _charactersOnScene.Count;
        if (id > spawnPositions.Length) throw new Exception($"There's not enough places to spawn {id+1} characters");
        
        var prefab = character.Prefab;
        var inst = Instantiate(prefab, spawnPositions[id]);
        var manager = inst.GetComponent<CharacterManager>();
        _charactersOnScene.Add(character);
        _managers.Add(character, manager);
    }

    //TODO make characters play exit animation before destroying them
    private void DestroyCharacter()
    {
        
    }
}
