using UnityEngine;

[CreateAssetMenu]
public class Progression : ScriptableObject
{
    [SerializeField] private CurrentCutscene cutscene;
    [SerializeField] private Navigator navigator;
    
    public void BeginCutscene(Cutscene c)
    {
        cutscene.Set(c);
        navigator.NavigateToCutscenePlayer();
    }
}