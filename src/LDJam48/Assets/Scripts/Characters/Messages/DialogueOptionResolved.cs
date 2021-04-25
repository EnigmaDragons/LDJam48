
using System.Collections.Generic;

public class DialogueOptionResolved
{
    public DialogueOption Selected { get; }
    public Dictionary<Character, int> PlayerSuspicionChange { get; }

    public DialogueOptionResolved(DialogueOption option, Dictionary<Character, int> playerSuspicionChange)
    {
        Selected = option;
        PlayerSuspicionChange = playerSuspicionChange;
    }
}