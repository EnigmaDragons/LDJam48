using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCspawner : OnMessage<StartConversation>
{
    protected override void Execute(StartConversation msg)
    {
        foreach (var character in msg.Conversation.NonPlayerCharacters)
        {
            SpawnCharacter(character.Prefab);
        }
    }

    private void SpawnCharacter(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }

    private void DestroyCharacter()
    {
        
    }
}
