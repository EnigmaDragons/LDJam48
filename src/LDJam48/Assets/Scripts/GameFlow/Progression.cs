using UnityEngine;

[CreateAssetMenu]
public class Progression : ScriptableObject
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private CurrentCutscene cutscene;
    [SerializeField] private Navigator navigator;
    
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
}
