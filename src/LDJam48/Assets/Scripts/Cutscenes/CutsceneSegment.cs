using System;
using UnityEngine;

[Serializable]
public class CutsceneSegment
{
    [SerializeField] private GameObject artBackground;
    [SerializeField] private string storyText;
    [SerializeField] private Color textColor = new Color(0, 0, 0);

    public GameObject ArtBackground => artBackground;
    public string StoryText => storyText;
    public Color TextColor => textColor;

    public void Begin() => Message.Publish(new PlayCutsceneSegment(this));
}