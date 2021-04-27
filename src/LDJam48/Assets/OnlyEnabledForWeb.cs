using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyEnabledForWeb : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    private void OnEnable()
    {
        var t = target == null ? gameObject : target;
        t.SetActive(false);
        
        #if UNITY_WEBGL
            t.SetActive(true);
        #endif
    }
}
