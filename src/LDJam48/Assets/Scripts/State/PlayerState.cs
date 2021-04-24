using UnityEngine;

[CreateAssetMenu]
public class PlayerState : ScriptableObject
{
    [SerializeField] private Character character;
    
    public Character Character => character;
}