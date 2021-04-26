using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSuspicion : MonoBehaviour
{
    [SerializeField] private Slider suspicionSlider;
    [SerializeField] private Character character;

    private int _lastValue;
    
    private void OnEnable()
    {
        character.ONSuspicionChange += UpdateUI;
        UpdateUI(false);
    }

    private void OnDisable() => character.ONSuspicionChange -= UpdateUI;

    private void UpdateUI() => UpdateUI(true);
    private void UpdateUI(bool canPunch)
    {
        var currentSus = character.GetSuspicion();
        suspicionSlider.maxValue = character.GetMaxSuspicion();
        suspicionSlider.value = currentSus;
        if (canPunch && character.GetSuspicion() > 0 && currentSus > _lastValue)
            suspicionSlider.gameObject.transform.DOPunchScale(new Vector3(1.6f, 1.6f, 1.6f), 1f, 1);
        _lastValue = currentSus;
    }
}
