using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSuspicion : MonoBehaviour
{
    [SerializeField] private Slider suspicionSlider;

    [SerializeField] private Character character;

    private void Awake()
    {
        character.ONSuspicionChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        suspicionSlider.maxValue = character.GetMaxSuspicion();
        suspicionSlider.value = character.GetSuspicion();
    }
}
