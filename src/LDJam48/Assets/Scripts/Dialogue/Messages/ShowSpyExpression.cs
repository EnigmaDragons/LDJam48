namespace Dialogue.Messages
{
    public class ShowSpyExpression
    {
        public string Emotion { get; }

        public ShowSpyExpression(string expression)
        {
            Emotion = expression;
        }
    }
}