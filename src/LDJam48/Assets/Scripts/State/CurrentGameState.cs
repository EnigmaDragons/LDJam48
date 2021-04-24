using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GameTemplate/OnlyOnce/CurrentGameState")]
public sealed class CurrentGameState : ScriptableObject
{
    [SerializeField] private GameState gameState;
    [SerializeField] private CurrentConversation conversation;
    [SerializeField] private PlayerState player;
    [SerializeField] private Location currentLocation;
    [SerializeField] private int locationConversationIndex;

    public int LocationConversationIndex => locationConversationIndex;
    public Location CurrentLocation => currentLocation;
    public void AdvanceLocationConversation() => locationConversationIndex++;

    public void SetLocation(Location l)
    {
        locationConversationIndex = 0;
        currentLocation = l;
    }

    public void Init() => gameState = new GameState();
    public void Init(GameState initialState) => gameState = initialState;
    public void Subscribe(Action<GameStateChanged> onChange, object owner) => Message.Subscribe(onChange, owner);
    public void Unsubscribe(object owner) => Message.Unsubscribe(owner);
    
    public void UpdateState(Action<GameState> apply)
    {
        UpdateState(_ =>
        {
            apply(gameState);
            return gameState;
        });
    }
    
    public void UpdateState(Func<GameState, GameState> apply)
    {
        gameState = apply(gameState);
        Message.Publish(new GameStateChanged(gameState));
    }
}
