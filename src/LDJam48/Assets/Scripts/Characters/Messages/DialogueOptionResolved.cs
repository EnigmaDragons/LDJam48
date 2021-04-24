
public class DialogueOptionResolved
{
    public DialogueOption Selected { get; }
    public int PlayerSuspicionChange { get; }

    public DialogueOptionResolved(DialogueOption option, int playerSuspicionChange)
    {
        Selected = option;
        PlayerSuspicionChange = playerSuspicionChange;
    }
}