using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue.Messages;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Transform playerSpawnPosition;
    private List<Character> _charactersOnScene = new List<Character>();
    private Dictionary<Character, CharacterManager> _managers = new Dictionary<Character, CharacterManager>();

    private void Awake()
    {
        _charactersOnScene = new List<Character>();
        _managers = new Dictionary<Character, CharacterManager>();
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

    public void SpawnPlayerCharacter(Character character)
    {
        var prefab = character.Prefab;
        var inst = Instantiate(prefab, playerSpawnPosition);
        var manager = inst.GetComponent<CharacterManager>();
        _charactersOnScene.Add(character);
        _managers.Add(character, manager);
    }
    
    //TODO make characters play exit animation before destroying them
    private void DestroyCharacter()
    {
        
    }
}
