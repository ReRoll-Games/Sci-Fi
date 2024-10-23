using System;
using UnityEngine;
using VG;

public class ItemDrop : MonoBehaviour
{
    public event Action onCollected;

    [SerializeField] private ItemType _itemType;
    [SerializeField] private AreaTrigger _areaTrigger;

    private int _amount = 1;


    public void SetAmount(int value) => _amount = value;


    private void OnEnable()
    {
        _areaTrigger.onEnter += OnPlayerEnter;
    }

    private void OnDisable()
    {
        _areaTrigger.onEnter -= OnPlayerEnter;
    }


    private void OnPlayerEnter()
    {
        Saves.Int[Key_Save.item_amount(_itemType)].Value += _amount;
        onCollected?.Invoke();
        Destroy(gameObject);

        GameEvents.ItemCollected(new ItemPack 
        { 
            amount = _amount,
            itemType = _itemType 
        });
    }


}
