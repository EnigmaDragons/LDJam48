
using System;
using UnityEngine;

[Serializable]
public class Expression
{
    [SerializeField] private StringReference expressionType;
    [SerializeField] private Sprite sprite;

    public StringReference ExpressionType => expressionType;
    public Sprite Sprite => sprite;
}