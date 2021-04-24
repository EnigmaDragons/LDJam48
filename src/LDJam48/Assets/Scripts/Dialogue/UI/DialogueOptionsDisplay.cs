using UnityEngine;

public class DialogueOptionsDisplay : OnMessage<ShowDialogueOptions, DialogueOptionSelected>
{
    [SerializeField] private GameObject optionsParent;
    [SerializeField] private OptionButton optionButtonPrototype;

    private void Awake() => Hide();
    
    protected override void Execute(ShowDialogueOptions msg)
    {
        msg.Options.ForEachArr(o => Instantiate(optionButtonPrototype, optionsParent.transform)
            .Initialized(o.Text, o.Select));
    }

    protected override void Execute(DialogueOptionSelected msg) => Hide();

    private void Hide() => optionsParent.DestroyAllChildren();
}