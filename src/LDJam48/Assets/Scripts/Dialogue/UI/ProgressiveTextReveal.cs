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
    [SerializeField] private FloatReference autoAdvanceDelay = new FloatReference(0.8f);
    [SerializeField, ReadOnly] private bool isRevealing;
    [SerializeField, ReadOnly] private string fullText;
    
    private int _cursor;
    private Color _defaultTextColor;
    private bool _showAutoProceed = false;
    private bool _proceeded = false;
    private Action _onFinished = () => { };

    private void Awake()
    {
        chatBox.onClick.AddListener(Proceed);
        _defaultTextColor = FullAlphaColor(textBox.color);
    }

    public void Hide()
    {
        if (!chatBox.gameObject.activeSelf || isRevealing)
            return;
        
        Log.Info($"Hide Speech Bubble", this);
        chatBox.gameObject.SetActive(false);
    }

    public void Display(string text) => Display(text,  _defaultTextColor, false, () => { });
    public void Display(string text, Action onFinished) => Display(text, _defaultTextColor, false, onFinished);
    public void Display(string text, bool shouldAutoProceed, Action onFinished) => Display(text, _defaultTextColor, shouldAutoProceed, onFinished);
    public void Display(string text, Color textColor, bool shouldAutoProceed, Action onFinished)
    {
        if (isRevealing)
            return;

        chatBox.gameObject.SetActive(true);
        textBox.color = FullAlphaColor(textColor);
        fullText = text;
        _onFinished = onFinished;
        _showAutoProceed = shouldAutoProceed;
        _proceeded = false;
        StartCoroutine(BeginReveal());
    }

    public void Proceed()
    {
        if (isRevealing)
            ShowCompletely();
        else if (!_proceeded)
        {
            _proceeded = true;
            if (_showAutoProceed)
                this.ExecuteAfterDelay(_onFinished, autoAdvanceDelay);
            else
                _onFinished();
        }
    }
    
    public void ShowCompletely()
    {
        textBox.text = fullText;
        isRevealing = false;
        if (_showAutoProceed)
            Proceed();
    }

    private IEnumerator BeginReveal()
    {
        isRevealing = true;
        chatBox.gameObject.SetActive(true);
        _cursor = 1;
        while (isRevealing && _cursor < fullText.Length)
        {
            var shownText = fullText.Substring(0, _cursor);
            textBox.text = shownText;
            _cursor++;
            yield return new WaitForSeconds(secondsPerCharacter);
        }
        ShowCompletely();
    }
    
    private Color FullAlphaColor(Color c) => new Color(c.r, c.g, c.b, 1f);
}