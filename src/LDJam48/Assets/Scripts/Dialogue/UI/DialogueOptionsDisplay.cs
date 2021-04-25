using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionsDisplay : OnMessage<ShowDialogueOptions, DialogueOptionSelected>
{
    [SerializeField] private GameObject optionsParent;
    [SerializeField] private OptionButton optionButtonPrototype;

    private readonly List<OptionButton> _options = new List<OptionButton>();
    
    private void Awake() => Hide();
    
    protected override void Execute(ShowDialogueOptions msg)
    {
        Log.Info($"Show {msg.Options.Length} Dialogue Options");
        Hide();
        msg.Options.ForEachArr(o => _options.Add(Instantiate(optionButtonPrototype, optionsParent.transform)
            .Initialized(o.Text, o.Select)));
    }

    protected override void Execute(DialogueOptionSelected msg) => Hide();

    private void Hide()
    {
        optionsParent.DestroyAllChildren();
        _options.Clear();
    }

    public void SelectOption(int index)
    {
        if (_options.Count > index)
            _options[index].Select();
    }
}