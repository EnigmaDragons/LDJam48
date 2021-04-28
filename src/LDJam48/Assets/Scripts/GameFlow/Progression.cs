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
        ResetCharacters();
    }

    private void ResetCharacters()
    {
        allCharacters.ForEachArr(c => c.Flush());
    }

    public void BeginCutscene(Cutscene c)
    {
        cutscene.Set(c);
        navigator.NavigateToCutscenePlayer();
    }

    public void RestartFromCheckpoint()
    {
        if (gameState.CheckpointLocation == null)
            return;
        
        ResetCharacters();
        gameState.SetLocation(gameState.CheckpointLocation);
        navigator.NavigateToLocationScene();
    }

    public void GoToLocation(Location l)
    {
        gameState.SetLocation(l);
        navigator.NavigateToLocationScene();
    }

    public void GoToVictory()
    {
        gameState.UpdateState(g => g.IsVictory = true);
        navigator.NavigateToCreditsScene();
    }
    
    public void SkipCutscene() => Message.Publish(new SkipCutscene());
    
    public void ResetSuspicion()
    {
        allCharacters.ForEachArr(c => c.Flush());
    }
}
