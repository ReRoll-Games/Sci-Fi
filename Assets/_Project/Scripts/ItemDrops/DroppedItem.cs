using System;
using UnityEngine;
using VG;

public class DroppedItem : MonoBehaviour
{
    public event Action onCollected;

    [SerializeField] private ItemType _itemType;
    [SerializeField] private AreaTrigger _areaTrigger;


    private void Awake()
    {
        _areaTrigger.onEnter += OnPlayerEnter;
    }

    private void OnDestroy()
    {
        _areaTrigger.onEnter -= OnPlayerEnter;
    }


    private void OnPlayerEnter()
    {
        Saves.Int[Key_Save.item_amount(_itemType)].Value++;
        onCollected?.Invoke();
        Destroy(gameObject);

        GameEvents.ItemCollected(new ItemPack 
        { 
            amount = 1,
            itemType = _itemType 
        });
    }


}
