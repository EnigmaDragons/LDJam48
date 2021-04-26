using TMPro;
using UnityEngine;

public class CutsceneSegmentPresenter : OnMessage<PlayCutsceneSegment>
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TextMeshProUGUI textBox;

    private GameObject _lastArtBackgroundPrototype;
    private GameObject _currentSegment;
    private CutsceneSegment _lastSegment;
    
    protected override void Execute(PlayCutsceneSegment msg)
    {
        var segment = msg.Segment;
        if (_lastSegment == segment)
            return;

        if (_lastArtBackgroundPrototype != segment.ArtBackground)
        {
            parent.DestroyAllChildren();
            if (segment.ArtBackground != null)
                _currentSegment = Instantiate(segment.ArtBackground, parent.transform);
        }
        
        Log.Info($"Cutscene - {segment.StoryText}");
        var targetTextbox = textBox;
        if (_currentSegment != null)
        {
            var segmentCustomTextLocation = _currentSegment.transform.GetComponentInChildren<TextMeshProUGUI>();
            if (segmentCustomTextLocation != null)
                targetTextbox = segmentCustomTextLocation;
        }

        textBox.text = "";
        targetTextbox.text = "";
        
        if (segment.ShouldShowStoryText)
        {
            targetTextbox.text = segment.StoryText;
            targetTextbox.color = FullAlphaColor(segment.TextColor);
        }

        _lastArtBackgroundPrototype = segment.ArtBackground;
        _lastSegment = segment;
        this.ExecuteAfterDelay(() => Message.Publish(new AdvanceCutscene()), segment.DurationSeconds);
    }

    private Color FullAlphaColor(Color c) => new Color(c.r, c.g, c.b, 1f);
}