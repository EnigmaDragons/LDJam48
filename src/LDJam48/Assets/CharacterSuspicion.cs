using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSuspicion : MonoBehaviour
{
    [SerializeField] private Slider suspicionSlider;
    [SerializeField] private Character character;

    private int _lastValue;
    
    private void Awake()
    {
        character.ONSuspicionChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        var currentSus = character.GetSuspicion();
        suspicionSlider.maxValue = character.GetMaxSuspicion();
        suspicionSlider.value = currentSus;
        if (character.GetSuspicion() > 0 && _lastValue != currentSus)
            suspicionSlider.gameObject.transform.DOPunchScale(new Vector3(1.6f, 1.6f, 1.6f), 1f, 1);
        _lastValue = currentSus;
    }
}
