using System;
using System.Collections.Generic;
using System.Linq;
using Tags;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class Character : ScriptableObject, IEqualityComparer<Character>
{
    public string CharacterName;
    public GameObject Prefab;
    [SerializeField] private TagObject[] startTags;
    [SerializeField] private List<TagObject> learnedTags;
    [SerializeField] private int maxSus;
    [SerializeField] private int startingSus;
    [SerializeField] private int suspicion;
    public Action ONSuspicionChange;
    
    private void OnValidate()
    {
        Flush();
    }

    public void AddSuspicion(int amount)
    {
        suspicion += amount;
        ONSuspicionChange?.Invoke();
    }

    public int GetSuspicion()
    {
        return suspicion;
    }
    
    public int GetMaxSuspicion()
    {
        return maxSus;
    }

    public bool IsSus()
    {
        return suspicion >= maxSus;
    }

    public void Flush()
    {
        ONSuspicionChange = () => {};
        learnedTags = new List<TagObject>();
        learnedTags = (startTags ?? new TagObject[0]).ToList();
        suspicion = startingSus;
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

    public bool Equals(Character x, Character y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.CharacterName == y.CharacterName && x.maxSus == y.maxSus;
    }

    public int GetHashCode(Character obj)
    {
        unchecked
        {
            return ((obj.CharacterName != null ? obj.CharacterName.GetHashCode() : 0) * 397) ^ obj.maxSus;
        }
    }
}