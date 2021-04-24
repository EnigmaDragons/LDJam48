
public class ShowStatement
{
    public Character SpeakingCharacter { get; }
    public string Statement { get; }

    public ShowStatement(Character c, string statement)
    {
        SpeakingCharacter = c;
        Statement = statement;
    }
}
