using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class ExpressionSet
{
    [SerializeField] private Expression defaultExpression;
    [SerializeField] private Expression[] expressions;

    public Expression this[string type] => expressions.FirstOrDefault(e => e.ExpressionType.Value.Equals(type)) ?? defaultExpression;
}