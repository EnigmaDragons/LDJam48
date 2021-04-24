using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button button;

    private Action _onSelected = () => {};

    private void Start() => button.onClick.AddListener(() => _onSelected());

    public OptionButton Initialized(string text, Action onSelected)
    {
        label.text = text;
        _onSelected = onSelected;
        return this;
    }
}