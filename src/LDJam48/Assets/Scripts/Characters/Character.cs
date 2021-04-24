using Tags;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string CharacterName;
    public GameObject Prefab;
    public TagObject[] learnedTags;
    [SerializeField] private int suspicion;

    public void AddSuspicion(int amount)
    {
        suspicion += amount;
    }

    public int GetSuspicion()
    {
        return suspicion;
    }
    
}