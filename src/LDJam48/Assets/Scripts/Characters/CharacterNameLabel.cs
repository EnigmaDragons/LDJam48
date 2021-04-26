using TMPro;
using UnityEngine;

public class CharacterNameLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    
    public void Init(string displayName)
    {
        nameLabel.text = displayName;
    }
}