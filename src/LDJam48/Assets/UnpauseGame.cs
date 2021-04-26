using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseGame : MonoBehaviour
{
    public void Unpause()
    {
        Time.timeScale = 1f;
    }
}
