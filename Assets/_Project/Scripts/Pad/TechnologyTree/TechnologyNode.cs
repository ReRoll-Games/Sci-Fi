using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class TechnologyNode : Info
{
    public enum State { Done, Available, Locked }

    [field: SerializeField] public TechnologyType TechnologyType { get; private set; }
    [field: SerializeField] public int Level { get; private set; }

    [SerializeField] private TechnologyNode _requiredNode;
    [Space(10)]
    [SerializeField] private Color _doneColor;
    [SerializeField] private Color _availableColor;
    [SerializeField] private Color _lockedColor;
    [SerializeField] private Button _button;

    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private List<Image> _colorElements;
    [SerializeField] private List<Image> _edges;


    protected override void Subscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        int currentLevel = Saves.GetTechnologyLevel(TechnologyType);

        if (currentLevel >= Level) SetState(State.Done);
        else
        {
            int requiredTechnologyLevel = Saves.GetTechnologyLevel(_requiredNode.TechnologyType);

            if (requiredTechnologyLevel >= _requiredNode.Level)
                SetState(State.Available);

            else SetState(State.Locked);
        }
    }


    private void SetState(State state)
    {
        Color mainColor = new Color();
        
        switch (state)
        {
            case State.Done: mainColor = _doneColor;
                break;
            case State.Available: mainColor = _availableColor;
                break;
            case State.Locked: mainColor = _lockedColor;
                break;
        }

        for (int i = 0; i < _colorElements.Count; i++)
            _colorElements[i].color = mainColor;

        Color edgeColor = state == State.Done ? _doneColor : _lockedColor;
        for (int i = 0; i < _edges.Count; i++)
            _edges[i].color = edgeColor;

        _numberText.color = mainColor;

        _button.interactable = state != State.Locked;
    }

    
}