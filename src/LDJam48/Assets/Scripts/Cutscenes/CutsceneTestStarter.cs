using UnityEngine;

public class CutsceneTestStarter : MonoBehaviour
{
    [SerializeField] private Cutscene cutscene;

    private void Update()
    {
        if (cutscene == null) 
            return;
        
        Message.Publish(new ShowCutscene(cutscene));
        cutscene = null;
    }
}