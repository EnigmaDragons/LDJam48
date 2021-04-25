using System;
using UnityEngine;

[Serializable]
public class FollowupDialogueData
{
    [SerializeField] private Character speakingCharacter;
    [TextArea] [SerializeField] private string statement;
    [SerializeField] private StringReference statementEmotion = new StringReference("Default"); 
    [SerializeField] private bool onlyShowIfCharacterLikedAnswer;

    private bool MatchesCharacter(Character c) => speakingCharacter == c;
    public Character SpeakingCharacter => speakingCharacter;
    public bool ShouldShow(Character c, int susAmount) =>
        MatchesCharacter(c)
        && (onlyShowIfCharacterLikedAnswer && susAmount < 1) 
        || (!onlyShowIfCharacterLikedAnswer && susAmount > 0);
    public void Begin() => Message.Publish(new ShowStatement(speakingCharacter, statement, statementEmotion));
}