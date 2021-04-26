using TMPro;
using UnityEngine;

public class ChangeTmpFontColor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Color targetColor;

    private Color _initialColor;

    private void Awake() => _initialColor = text.color;

    private void OnEnable() => Revert();
    private void OnDisable() => Revert();

    public void Revert() => text.color = _initialColor;
    public void Apply() => text.color = targetColor;
}