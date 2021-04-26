namespace Dialogue.Messages
{
    public class ShowGameOverLine
    {
        public Character SpeakingCharacter;
        public ShowGameOverLine(Character character) => SpeakingCharacter = character;
    }
}