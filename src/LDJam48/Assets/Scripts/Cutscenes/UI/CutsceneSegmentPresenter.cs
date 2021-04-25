using UnityEngine;

public class CutsceneSegmentPresenter : OnMessage<PlayCutsceneSegment>
{
    [SerializeField] private GameObject parent;
    [SerializeField] private ProgressiveTextReveal text;

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
        text.Display(segment.StoryText, segment.TextColor, true, () => Message.Publish(new AdvanceCutscene()));
        _lastArtBackground = segment.ArtBackground;
        _lastSegment = segment;
    }
}