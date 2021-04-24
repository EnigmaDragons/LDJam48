
public class DialogueOptionSelected
{
    public DialogueOption Selection { get; }
    public Character CurrentCharacter { get; } // TODO: Need to record all Characters Present. Probably shouldn't flow through this data structure

    public DialogueOptionSelected(DialogueOption o, Character c)
    {
        Selection = o;
        CurrentCharacter = c;
    }
}
