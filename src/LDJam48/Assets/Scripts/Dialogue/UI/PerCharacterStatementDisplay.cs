using UnityEngine;

public class PerCharacterStatementDisplay : OnMessage<ShowStatement, HideStatements>
{
    [SerializeField] private ScenePositions scene;
    [SerializeField] private CurrentConversation conversation;

    protected override void Execute(ShowStatement msg)
    {
        scene.HideOthers(msg.SpeakingCharacter);
        scene.SpeechForCharacter(msg.SpeakingCharacter)
            .Display(msg.Statement, conversation.NextSequenceIsOptions,() => Message.Publish(new AdvanceConversation()));
    }

    protected override void Execute(HideStatements msg) => scene.HideAll();
}