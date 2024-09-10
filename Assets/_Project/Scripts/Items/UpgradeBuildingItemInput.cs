using UnityEngine;
using VG;


public class UpgradeBuildingItemInput : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private AreaTrigger _areaTrigger;
    [SerializeField] private Transform _dropPosition;

    private const float inputCicleDuration = 0.15f;

    private bool _inputProcess = false;
    private bool _itemDropping = false;
    private float _timeToInputLeft = 0f;

    private void OnEnable()
    {
        _areaTrigger.onEnter += OnAreaEnter;
        _areaTrigger.onExit += OnAreaExit;
    }

    private void OnDisable()
    {
        _areaTrigger.onEnter -= OnAreaEnter;
        _areaTrigger.onExit -= OnAreaExit;
    }

    private void Update()
    {
        if (_inputProcess) InputProcess();
    }


    private void InputProcess()
    {
        _timeToInputLeft -= Time.deltaTime;
        if (_timeToInputLeft < 0f && !_itemDropping)
        {
            _timeToInputLeft = inputCicleDuration;
            OnDropItemCicle();
        }
    }


    private void OnDropItemCicle()
    {
        var itemsNeed = Saves.GetItemsNeedForUpgradeBuilding(_building.index);

        for (int i = 0; i < itemsNeed.Count; i++)
        {
            var itemPack = itemsNeed[i];
            if (itemPack.quantity > 0 && Inventory.HasItem(itemPack.itemType))
            {
                _itemDropping = true;
                Inventory.Drop(itemPack.itemType, _dropPosition.position, onDropped: () =>
                {
                    Saves.DropItemToBuildingUpgrade(itemPack.itemType, _building.index);
                    _itemDropping = false;
                });
                return;
            }
        }
    }


    private void OnAreaExit()
    {
        _inputProcess = false;
    }

    private void OnAreaEnter()
    {
        _inputProcess = true;
    }



}
