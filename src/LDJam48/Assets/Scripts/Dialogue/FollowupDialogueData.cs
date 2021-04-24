using System;
using UnityEngine;

[Serializable]
public class FollowupDialogueData
{
    [SerializeField] private Character speakingCharacter;
    [SerializeField] private string statement;
    
    public void Begin() => Message.Publish(new ShowStatement(speakingCharacter, statement));
}