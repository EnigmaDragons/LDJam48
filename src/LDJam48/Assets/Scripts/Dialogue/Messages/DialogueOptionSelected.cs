
public class DialogueOptionSelected
{
    public DialogueOption Selection { get; }
    public Character CurrentCharacter;

    public DialogueOptionSelected(DialogueOption o, Character c)
    {
        Selection = o;
        CurrentCharacter = c;
    }
}
