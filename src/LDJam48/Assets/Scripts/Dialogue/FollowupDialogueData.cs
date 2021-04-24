using System;
using UnityEngine;

[Serializable]
public class FollowupDialogueData
{
    [SerializeField] private Character speakingCharacter;
    [SerializeField] private string statement;
    [SerializeField] private bool onlyShowIfCharacterLikedAnswer;

    public bool OnlyShowIfCharacterLikedAnswer => onlyShowIfCharacterLikedAnswer;
    public void Begin() => Message.Publish(new ShowStatement(speakingCharacter, statement));
}