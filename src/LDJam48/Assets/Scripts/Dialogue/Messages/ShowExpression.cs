namespace Dialogue.Messages
{
    public class ShowExpression
    {
    public Character Character { get; }
    public string Emotion { get; }

    public ShowExpression(Character character, string emotion)
    {
        Character = character;
        Emotion = emotion;
    }

    
    }
}