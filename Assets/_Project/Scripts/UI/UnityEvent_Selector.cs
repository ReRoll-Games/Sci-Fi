using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_Selector : SelectorHandler
{
    [SerializeField] private UnityEvent _onSelect;

    public override void Select()
    {
        _onSelect?.Invoke();
    }
}
