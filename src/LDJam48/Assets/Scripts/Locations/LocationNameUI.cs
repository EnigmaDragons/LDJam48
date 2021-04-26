using UnityEngine;
using UnityEngine.UI;

public class LocationNameUI : MonoBehaviour
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private Image image;

    private void Awake() => image.sprite = gameState.CurrentLocation.LocationIcon;
}