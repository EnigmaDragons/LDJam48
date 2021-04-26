using UnityEngine;
using UnityEngine.UI;

public class ChangeImageTint : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color targetColor;

    private Color _initialColor;

    private void Awake() => _initialColor = image.color;

    private void OnEnable() => Revert();
    private void OnDisable() => Revert();

    public void Revert() => image.color = _initialColor;
    public void Apply() => image.color = targetColor;
}
