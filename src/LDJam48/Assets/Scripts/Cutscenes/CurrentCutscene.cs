using UnityEngine;

[CreateAssetMenu]
public class CurrentCutscene : ScriptableObject
{
    [SerializeField] private Cutscene current;

    public void Set(Cutscene c) => current = c;
    public Cutscene Current => current;
}