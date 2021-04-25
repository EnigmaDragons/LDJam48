using System;
using UnityEngine;

[Serializable]
public class CutsceneSegment
{
    [SerializeField] private GameObject artBackground;
    [SerializeField] private string storyText;
    [SerializeField] private Color textColor = new Color(0, 0, 0);
    [SerializeField] private float durationSeconds = 4f;

    public GameObject ArtBackground => artBackground;
    public string StoryText => storyText;
    public Color TextColor => textColor;
    public float DurationSeconds => durationSeconds;

    public void Begin() => Message.Publish(new PlayCutsceneSegment(this));
}