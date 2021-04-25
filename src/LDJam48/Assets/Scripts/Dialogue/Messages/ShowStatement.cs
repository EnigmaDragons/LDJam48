
public class ShowStatement
{
    public Character SpeakingCharacter { get; }
    public string Statement { get; }
    public StringReference Emotion { get; }

    public ShowStatement(Character c, string statement, StringReference emotion)
    {
        SpeakingCharacter = c;
        Statement = statement;
        Emotion = emotion;
    }
}
