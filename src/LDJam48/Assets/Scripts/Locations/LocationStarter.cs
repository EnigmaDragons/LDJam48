
using UnityEngine;

public class LocationStarter : MonoBehaviour
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private GameObject worldParent;

    private void Awake()
    {
        Instantiate(gameState.CurrentLocation.Obj, worldParent.transform);
    }

    private void Start()
    {
        Message.Publish(new StartConversation(gameState.CurrentLocation.Conversations[0]));
    }
}