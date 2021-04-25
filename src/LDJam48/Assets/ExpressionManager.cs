using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpressionManager : OnMessage<ShowStatement>
{
    [SerializeField] private Character character;
    [SerializeField] private Image bust;
    
    private void SetExpression(string expression)
    {
        bust.sprite = character.Expression(expression).Sprite;
    }

    protected override void Execute(ShowStatement msg)
    {
        var cr = msg.SpeakingCharacter;
        if (cr != character) return;
        
        var expression = msg.Emotion != null && !string.IsNullOrWhiteSpace(msg.Emotion.Value)
            ? msg.Emotion.Value
            : "Default";
        
        SetExpression(expression);
    }
}
