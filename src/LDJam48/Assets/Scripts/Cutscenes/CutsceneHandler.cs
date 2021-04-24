
using UnityEngine;

public class CutsceneHandler : OnMessage<ShowCutscene, AdvanceCutscene, SkipCutscene>
{
    [SerializeField] private CurrentCutscene cutscene;
    
    private int _sequenceIndex = 0;
    
    protected override void Execute(ShowCutscene msg)
    {
        cutscene.Set(msg.Cutscene);
        _sequenceIndex = 0;
        BeginSegment();
    }

    protected override void Execute(AdvanceCutscene msg)
    {
        _sequenceIndex++;
        BeginSegment();
    }

    protected override void Execute(SkipCutscene msg) 
        => cutscene.Current.OnFinished.Invoke();

    private void BeginSegment()
    {
        var c = cutscene.Current;
        if (c.Segments.Length > _sequenceIndex)
            c.Segments[_sequenceIndex].Begin();
        else
            c.OnFinished.Invoke();
    }
}
