using UnityEngine;

[CreateAssetMenu]
public class Progression : ScriptableObject
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private CurrentCutscene cutscene;
    [SerializeField] private Navigator navigator;
    [SerializeField] private Character[] allCharacters;

    public void StartNewGame()
    {
        gameState.Init();
        allCharacters.ForEachArr(c => c.Flush());
    }
    
    public void BeginCutscene(Cutscene c)
    {
        cutscene.Set(c);
        navigator.NavigateToCutscenePlayer();
    }

    public void GoToLocation(Location l)
    {
        gameState.SetLocation(l);
        navigator.NavigateToLocationScene();
    }

    public void SkipCutscene() => Message.Publish(new SkipCutscene());
}
