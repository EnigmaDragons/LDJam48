using UnityEngine;

public class AutoStartCutscene : MonoBehaviour
{
    [SerializeField] private CurrentCutscene cutscene;

    private bool _triggered = false;
    
    private void Update()
    {
        if (_triggered || cutscene.Current == null) 
            return;
        
        Debug.Log("Triggered Cutscene");
        _triggered = true;
        Message.Publish(new ShowCutscene(cutscene.Current));
    }
}