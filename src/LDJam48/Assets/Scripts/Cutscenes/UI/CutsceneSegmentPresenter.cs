using TMPro;
using UnityEngine;

public class CutsceneSegmentPresenter : OnMessage<PlayCutsceneSegment>
{
    [SerializeField] private GameObject parent;
    [SerializeField] private TextMeshProUGUI textBox;

    private GameObject _lastArtBackground;
    private CutsceneSegment _lastSegment;
    
    protected override void Execute(PlayCutsceneSegment msg)
    {
        var segment = msg.Segment;
        if (_lastSegment == segment)
            return;
        
        if (_lastArtBackground != segment.ArtBackground)
        {
            parent.DestroyAllChildren();
            if (segment.ArtBackground != null)
                Instantiate(segment.ArtBackground, parent.transform);
        }

        Log.Info($"Cutscene - {segment.StoryText}");
        textBox.text = "";
        if (segment.ShouldShowStoryText)
        {
            textBox.text = segment.StoryText;
            textBox.color = FullAlphaColor(segment.TextColor);
        }

        _lastArtBackground = segment.ArtBackground;
        _lastSegment = segment;
        this.ExecuteAfterDelay(() => Message.Publish(new AdvanceCutscene()), segment.DurationSeconds);
    }

    private Color FullAlphaColor(Color c) => new Color(c.r, c.g, c.b, 1f);
}