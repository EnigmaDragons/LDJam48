using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentConversation", menuName = "Dialogue/CurrentConversation")]
public class CurrentConversation : ScriptableObject
{
    [SerializeField] private Conversation conversation;
    [SerializeField] private int sequenceIndex;

    private readonly Queue<FollowupDialogueData> _temporaryFollowups = new Queue<FollowupDialogueData>();
    private readonly Queue<string> _playerCharacterLines = new Queue<string>();
    
    public Conversation Current => conversation;
    private DialogueData CurrentSequence => Current.Sequence[sequenceIndex];
    private bool HasSequence => Current.Sequence.Length > sequenceIndex;
    public bool NextSequenceIsOptions => _temporaryFollowups.None() && conversation.Sequence.Length > sequenceIndex + 1 && conversation.Sequence[sequenceIndex + 1].IsDialogueOptions;
    
    public void Set(Conversation c)
    {
        _temporaryFollowups.Clear();
        sequenceIndex = -1;
        conversation = c;
    }

    public void ExecuteNext()
    {
        if (_playerCharacterLines.Any())
            Message.Publish(new ShowStatement(conversation.PlayerCharacter, _playerCharacterLines.Dequeue(), new StringReference("Default")));
        else if (_temporaryFollowups.Any()) 
            _temporaryFollowups.Dequeue().Begin();
        else
        {
            sequenceIndex++;
            if (HasSequence)
                CurrentSequence.Begin();
            else
                Finish();
        }
    }

    private void Finish()
    {
        conversation.OnFinished.Invoke();
        Message.Publish(new AdvanceLocation());
    }

    public void Queue(FollowupDialogueData[] selectionFollowups)
    {
        selectionFollowups.ForEachArr(s => _temporaryFollowups.Enqueue(s));
    }

    public void QueuePlayerLine(string line) => _playerCharacterLines.Enqueue(line);
}