
using UnityEngine;

public class CutsceneSegmentPresenter : OnMessage<PlayCutsceneSegment>
{
    [SerializeField] private GameObject parent;
    [SerializeField] private ProgressiveTextReveal text;
    
    protected override void Execute(PlayCutsceneSegment msg)
    {
        var segment = msg.Segment;
        parent.DestroyAllChildren();
        Instantiate(segment.ArtBackground, parent.transform);
        text.Display(segment.StoryText, segment.TextColor, () => Message.Publish(new AdvanceCutscene()));
    }
}