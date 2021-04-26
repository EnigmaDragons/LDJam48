using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatVariableSlider : MonoBehaviour
{
    [SerializeField] private FloatVariable variable;
    [SerializeField] private Slider slider;
    [SerializeField] private bool inverseRelation;
    // Update is called once per frame
    private void Update()
    {
        if (inverseRelation)
        {
            variable.Value = slider.minValue + (slider.maxValue - slider.value);
            return;
        }
        variable.Value = slider.value;
    }
}
