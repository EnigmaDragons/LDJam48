using System;
using System.Collections.Generic;
using System.Linq;
using Tags;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class Character : ScriptableObject
{
    public string CharacterName;
    public GameObject Prefab;
    [SerializeField] private TagObject[] startTags;
    [SerializeField] private List<TagObject> learnedTags;
    [SerializeField] private int maxSus;
    [SerializeField] private int suspicion;
    
    private void OnValidate()
    {
        Flush();
    }

    public void AddSuspicion(int amount)
    {
        suspicion += amount;
    }

    public int GetSuspicion()
    {
        return suspicion;
    }

    public bool IsSus()
    {
        return suspicion >= maxSus;
    }

    public void Flush()
    {
        learnedTags = new List<TagObject>();
        learnedTags = startTags.ToList();
        suspicion = 0;
    }

    public void LearnTag(TagObject tag)
    {
        learnedTags.Add(tag);
    }

    public void LearnTags(List<TagObject> tags)
    {
        learnedTags.AddRange(tags);
    }

    public TagObject[] GetLearnedTags()
    {
        return learnedTags.ToArray();
    }
    
    
    
}