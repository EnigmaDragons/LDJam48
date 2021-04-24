
using UnityEngine;

public class CutsceneSegmentPresenter : OnMessage<PlayCutsceneSegment>
{
    [SerializeField] private GameObject parent;
    [SerializeField] private ProgressiveTextReveal text;

    private GameObject _lastArtBackground;
    
    protected override void Execute(PlayCutsceneSegment msg)
    {
        var segment = msg.Segment;
        if (_lastArtBackground != segment.ArtBackground)
        {
            parent.DestroyAllChildren();
            if (segment.ArtBackground != null)
                Instantiate(segment.ArtBackground, parent.transform);
        }

        text.Display(segment.StoryText, segment.TextColor, true, () => Message.Publish(new AdvanceCutscene()));
        _lastArtBackground = segment.ArtBackground;
    }
}