using System.Collections;
using System.Collections.Generic;
using Dialogue.Messages;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionManager : OnMessage<ShowStatement, ShowExpression, ShowSpyExpression>
{
    [SerializeField] private Character character;
    [SerializeField] private Image bust;
    
    private void SetExpression(string expression)
    {
        bust.sprite = character.Expression(expression).Sprite;
    }

    protected override void Execute(ShowStatement msg)
    {
        ShowExpression(msg.Emotion, msg.SpeakingCharacter);
    }
    
    protected override void Execute(ShowExpression msg)
    {
        ShowExpression(msg.Emotion, msg.Character);
    }

    protected override void Execute(ShowSpyExpression msg)
    {
        ShowPlayerExpression(msg.Emotion);
    }

    private void ShowPlayerExpression(string expression)
    {
        if (!character.IsPlayer()) return;
        
        var emotion = expression != null && !string.IsNullOrWhiteSpace(expression)
            ? expression
            : "Default";
        
        SetExpression(expression);
    }
    
    private void ShowExpression(string expression, Character cr)
    {
        if (cr != character) return;
        
        var emotion = expression != null && !string.IsNullOrWhiteSpace(expression)
            ? expression
            : "Default";
        
        SetExpression(expression);
    }
}
