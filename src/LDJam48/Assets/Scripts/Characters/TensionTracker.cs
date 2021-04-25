using System.Collections.Generic;
using System.Linq;
using Dialogue.Messages;using UnityEngine;

public class TensionTracker : OnMessage<SpawnCharacters, DialogueOptionResolved>
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private float tenseThreshold;
    [SerializeField] private float superTenseThreshold;

    private readonly HashSet<Character> _characters = new HashSet<Character>();
    
    protected override void Execute(SpawnCharacters msg)
    {
        msg.NPCs.ForEachArr(n => _characters.Add(n));
        UpdateTension();
    }

    protected override void Execute(DialogueOptionResolved msg)
    {
        UpdateTension();
    }

    private void UpdateTension()
    {
        var highestTensionCharacter = _characters.Max(c => c.GetSuspicionPercentage);
        var tensionLevel = TensionLevel.Calm;
        if (highestTensionCharacter > tenseThreshold)
            tensionLevel = TensionLevel.Tense;
        if (highestTensionCharacter > superTenseThreshold)
            tensionLevel = TensionLevel.SuperTense;

        if (tensionLevel != gameState.TensionLevel)
            gameState.UpdateState(g => g.TensionLevel = tensionLevel);
    }
}