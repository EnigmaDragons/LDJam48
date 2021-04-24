using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Cutscene : ScriptableObject
{
    [SerializeField] private CutsceneSegment[] segments;
    [SerializeField] private UnityEvent onFinishedAction;

    public CutsceneSegment[] Segments => segments.ToArray();
    public UnityEvent OnFinished => onFinishedAction;
}
