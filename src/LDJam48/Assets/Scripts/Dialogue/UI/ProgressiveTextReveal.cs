using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class ProgressiveTextReveal : MonoBehaviour
{
    [SerializeField] private Button chatBox;
    [SerializeField] private Image panelBg;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private FloatReference secondsPerCharacter = new FloatReference(0.07f);
    [SerializeField] private FloatReference autoAdvanceDelay = new FloatReference(0.8f);
    [SerializeField] private FloatReference cooldown = new FloatReference(0.15f);
    [SerializeField, ReadOnly] private bool isRevealing;
    [SerializeField, ReadOnly] private string fullText;
    
    private int _cursor;
    private Color _defaultTextColor;
    private bool _shouldAutoProceed = false;
    private bool _finished = false;
    private Action _onFinished = () => { };
    private float _cooldownRemaining = 0;

    private void Awake()
    {
        chatBox.onClick.AddListener(() => Proceed(isAuto: false));
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
        _shouldAutoProceed = shouldAutoProceed;
        _finished = false;
        StartCoroutine(BeginReveal());
    }

    public void Proceed() => Proceed(false);
    public void Proceed(bool isAuto)
    {
        Log.Info($"Text Box - Proceed Auto: {isAuto}");
        if (_finished)
            return;
        if (!isAuto)
            _shouldAutoProceed = false;
        if (isRevealing)
            ShowCompletely();
        else
        {
            Finish();
            return;
        }

        if (_shouldAutoProceed && isAuto)
            this.ExecuteAfterDelay(Finish, autoAdvanceDelay);
    }

    private void Finish()
    {
        if (_finished)
            return;
        
        Log.Info($"Text Box - Finished");
        _finished = true;
        _onFinished();
    }

    private void ShowCompletely()
    {
        Log.Info($"Text Box - Displayed Completely");
        isRevealing = false;
        textBox.text = fullText;
    }

    public void ReversePanelFacing()
    {
        if (panelBg != null)
            panelBg.transform.Rotate(0, 180, 0);
    }

    private IEnumerator BeginReveal()
    {
        if (secondsPerCharacter.Value < 0.01f)
        {
            ShowCompletely();
            Proceed(isAuto: true);
            yield break;
        }
        
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

        if (_shouldAutoProceed)
        {
            ShowCompletely();
            Proceed(isAuto: true);
        }
    }
    
    private Color FullAlphaColor(Color c) => new Color(c.r, c.g, c.b, 1f);
}