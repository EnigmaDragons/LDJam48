using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ProgressiveTextReveal : MonoBehaviour
{
    [SerializeField] private Button chatBox;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private FloatReference secondsPerCharacter = new FloatReference(0.07f);
    [SerializeField, ReadOnly] private bool isRevealing;
    
    private int _cursor;
    private Color _defaultTextColor;
    private string _fullText = "" ;
    private Action _onFinished = () => { };

    private void Awake()
    {
        chatBox.onClick.AddListener(Proceed);
        _defaultTextColor = textBox.color;
    }

    public void Hide() => chatBox.gameObject.SetActive(false);

    public void Display(string text) => Display(text,  _defaultTextColor,() => { });
    public void Display(string text, Action onFinished) => Display(text, _defaultTextColor, onFinished);
    public void Display(string text, Color textColor, Action onFinished)
    {
        if (isRevealing)
            return;

        textBox.color = textColor;
        _fullText = text;
        _onFinished = onFinished;
        StartCoroutine(BeginReveal());
    }

    public void Proceed()
    {
        if (isRevealing)
            ShowCompletely();
        else
            _onFinished();
    }
    
    public void ShowCompletely()
    {
        textBox.text = _fullText;
        isRevealing = false;
    }

    private IEnumerator BeginReveal()
    {
        isRevealing = true;
        chatBox.gameObject.SetActive(true);
        _cursor = 1;
        while (isRevealing && _cursor < _fullText.Length)
        {
            var shownText = _fullText.Substring(0, _cursor);
            textBox.text = shownText;
            _cursor++;
            yield return new WaitForSeconds(secondsPerCharacter);
        }
        ShowCompletely();
    }
}