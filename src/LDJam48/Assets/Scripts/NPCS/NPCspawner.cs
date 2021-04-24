using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCspawner : OnMessage<StartConversation>
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
    private void SpawnCharacter(Character character)
    {
        var prefab = character.Prefab;
        var inst = Instantiate(prefab, transform);
        var manager = inst.GetComponent<CharacterManager>();
        _charactersOnScene.Add(character);
        _managers.Add(character, manager);
    }

    //TODO make characters play exit animation before destroying them
    private void DestroyCharacter()
    {
        
    }
}
