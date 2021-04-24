namespace Dialogue.Messages
{
    public class SpawnCharacters
    {
        public Character[] ToSpawn;

        public SpawnCharacters(Character[] characters)
        {
            ToSpawn = characters;
        }
    }
}