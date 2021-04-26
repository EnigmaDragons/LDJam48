using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleDemo : MonoBehaviour
{
    [TextArea][SerializeField] private string demoString;
    [SerializeField] private FloatReference restartDelay;
    [SerializeField] private ProgressiveTextReveal text;
    private void OnEnable()
    {
        StartCoroutine(RestartWithDelay(0.1f));
    }
    
    public void RestartDisplay()
    {
        print("dsiplaying");
        StartCoroutine(RestartWithDelay(restartDelay.Value));
    }

    private IEnumerator RestartWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        text.Display(demoString, shouldAutoProceed: true ,onFinished: RestartDisplay);
    }
}
