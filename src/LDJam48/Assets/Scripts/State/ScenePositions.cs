using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class ScenePositions : ScriptableObject
{
    private Dictionary<Character, ProgressiveTextReveal> _characterSpeechBubbles = new Dictionary<Character, ProgressiveTextReveal>();

    public void Init()
    {
        _characterSpeechBubbles = new Dictionary<Character, ProgressiveTextReveal>();
    }

    public void Register(Character c, ProgressiveTextReveal speech) => _characterSpeechBubbles[c] = speech;
    public ProgressiveTextReveal SpeechForCharacter(Character c)
    {
        if (_characterSpeechBubbles.TryGetValue(c, out var value))
            return value;
        
        var msg = $"No Speech Bubble for {c.CharacterName} registered at Current Location";
        Log.Error(msg);
        throw new InvalidOperationException(msg);
    }

    public void HideOthers(Character speaking) => _characterSpeechBubbles
        .Where(x => x.Key != speaking)
        .ForEach(x => x.Value.Hide());
    
    
    public void HideAll() => _characterSpeechBubbles
        .ForEach(x => x.Value.Hide());
}