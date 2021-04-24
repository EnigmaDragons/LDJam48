using System.Collections.Generic;
using System.Linq;
using Tags;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string CharacterName;
    public GameObject Prefab;
    [SerializeField] private TagObject[] startTags;
    private List<TagObject> _learnedTags;
    [SerializeField] private int suspicion;

    public void AddSuspicion(int amount)
    {
        suspicion += amount;
    }

    public int GetSuspicion()
    {
        return suspicion;
    }

    public void Flush()
    {
        _learnedTags = startTags.ToList();
        suspicion = 0;
    }

    public void LearnTag(TagObject tag)
    {
        _learnedTags.Add(tag);
    }

    public void LearnTags(List<TagObject> tags)
    {
        _learnedTags.AddRange(tags);
    }

    public TagObject[] GetLearnedTags()
    {
        return _learnedTags.ToArray();
    }
    
    
    
}