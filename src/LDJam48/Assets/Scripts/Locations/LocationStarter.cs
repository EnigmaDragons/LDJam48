using UnityEngine;

public class LocationStarter : MonoBehaviour
{
    [SerializeField] private CurrentGameState gameState;
    [SerializeField] private ScenePositions scenePositions;
    [SerializeField] private GameObject worldParent;

    private void Awake()
    {
        scenePositions.Init();
        Instantiate(gameState.CurrentLocation.Obj, worldParent.transform);
    }

    private void Start()
    {
        Message.Publish(new StartConversation(gameState.CurrentLocation.Conversations[0]));
    }
}