using UnityEngine;

[CreateAssetMenu]
public sealed class Navigator : ScriptableObject
{
    [SerializeField] private bool loggingEnabled;
    
    public void NavigateToMainMenu() => NavigateTo("MainMenu");
    public void NavigateToCutscenePlayer() => NavigateTo("CutscenePlayer");
    public void NavigateToLocationScene() => NavigateTo("LocationScene");
    public void NavigateToCreditsScene() => NavigateTo("CreditsScene");
    public void NavigateToLocation1() => NavigateTo("FirstLocation");
    public void NavigateToScene(string sceneName) => NavigateTo(sceneName);

    private void NavigateTo(string sceneName)
    {
        if (loggingEnabled)
            Log.Info($"Navigating to {sceneName}");
        Message.Publish(new NavigateToSceneRequested(sceneName));
    }
}
