using UnityEngine;

[CreateAssetMenu(fileName = "CurrentConversation", menuName = "Dialogue/CurrentConversation")]
public class CurrentConversation : ScriptableObject
{
    [SerializeField] private Conversation conversation;
    [SerializeField] private int sequenceIndex;

    public Conversation Current => conversation;
    private DialogueData CurrentSequence => Current.Sequence[sequenceIndex];
    private bool HasSequence => Current.Sequence.Length > sequenceIndex;
    public bool NextSequenceIsOptions => conversation.Sequence.Length > sequenceIndex + 1 && conversation.Sequence[sequenceIndex + 1].IsDialogueOptions;
    
    public void Set(Conversation c)
    {
        sequenceIndex = 0;
        conversation = c;
    }

    public void ExecuteNext()
    {
        if (HasSequence)
            CurrentSequence.Begin();
        else
            Finish();
    }
    
    public void AdvanceSequence() => sequenceIndex++;
    private void Finish() => conversation.OnFinished.Invoke();

}