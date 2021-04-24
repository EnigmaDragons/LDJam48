namespace Dialogue.Messages
{
    public class SpawnCharacters
    {
        public Character[] NPCs;
        public Character PlayerCharacter;
        
        public SpawnCharacters(Character[] characters, Character playerCharacter)
        {
            NPCs = characters;
            PlayerCharacter = playerCharacter;
        }
    }
}