using UnityEngine;
using VG;

public abstract class ItemInput : MonoBehaviour
{
    [SerializeField] private AreaTrigger _areaTrigger;
    [SerializeField] private Transform _dropPosition;

    private const float inputCicleDuration = 0.15f;

    private bool _inputProcess = false;
    private bool _itemDropping = false;


    private void OnEnable()
    {
        _areaTrigger.onEnter += OnAreaEnter;
        _areaTrigger.onExit += OnAreaExit;
        Repeater.handlers[Key_Repeat.item_input_cicle].onUpdate += OnItemInputCicle;
    }

    private void OnDisable()
    {
        _areaTrigger.onEnter -= OnAreaEnter;
        _areaTrigger.onExit -= OnAreaExit;
        Repeater.handlers[Key_Repeat.item_input_cicle].onUpdate -= OnItemInputCicle;
    }

    private void OnAreaExit() => _inputProcess = false;

    private void OnAreaEnter() => _inputProcess = true;


    private void OnItemInputCicle()
    {
        if (_inputProcess) OnDropItemCicle();
    }



    private void OnDropItemCicle()
    {
        if (!inputAvailable || _itemDropping) return;

        _itemDropping = true;
        Inventory.Drop(dropItemType, _dropPosition.position, onDropped: () =>
        {
            OnItemDropped(dropItemType);
            _itemDropping = false;
        });
    }

    protected abstract bool inputAvailable { get; }
    protected abstract ItemType dropItemType { get; }
    protected abstract void OnItemDropped(ItemType itemType);

    

}
