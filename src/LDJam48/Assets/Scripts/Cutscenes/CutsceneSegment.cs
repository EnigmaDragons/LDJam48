using System;
using UnityEngine;

[Serializable]
public class CutsceneSegment
{
    [SerializeField] private GameObject artBackground;
    [SerializeField] public string storyText;
    [SerializeField] private Color textColor = new Color(0, 0, 0);
    [SerializeField] private bool showStoryText = true;
    [SerializeField] private float durationSeconds = 4f;

    public GameObject ArtBackground => artBackground;
    public string StoryText => storyText;
    public bool ShouldShowStoryText => showStoryText;
    public Color TextColor => textColor;
    public float DurationSeconds => durationSeconds;

    public void Begin() => Message.Publish(new PlayCutsceneSegment(this));
}