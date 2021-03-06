using System;
using System.Collections.Generic;
using System.Linq;
using Tags;
using UnityEngine;

[CreateAssetMenu]
public class Character : ScriptableObject, IEqualityComparer<Character>
{
    public string CharacterName;
    public GameObject Prefab;
    [SerializeField] private ExpressionSet expressions;
    [SerializeField] private FollowupDialogueData[] coverBlownStatements;
    
    [SerializeField] private int maxSus;
    [SerializeField] private int startingSus;
    [SerializeField] private int suspicion;
    [SerializeField] private bool isPlayer;
    
    [SerializeField] private TagObject[] startTags;
    [SerializeField] private List<TagObject> learnedTags;
    public Action ONSuspicionChange;
    
    private void OnValidate()
    {
        Flush();
    }

    public Expression Expression(string type) => expressions[type];
    
    public int AddSuspicion(int amount)
    {
        if (amount == 0)
            return 0;

        var before = suspicion;
        suspicion = Mathf.Clamp(suspicion + amount, 0, maxSus);
        if (suspicion - before == 0)
            return 0;
        
        Log.Info($"{CharacterName} suspicion is now {suspicion}/{maxSus}. Change {amount}");
        ONSuspicionChange?.Invoke();
        return suspicion - before;
    }

    public float GetSuspicionPercentage => suspicion / (float)maxSus;
    public FollowupDialogueData[] CoverBlownLines => coverBlownStatements.ToArray();
    
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

    public bool IsPlayer()
    {
        return isPlayer;
    }
}
