using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;

    [SerializeField] private int _slotsQuantity;
    [SerializeField] private InventoryItem _inventoryItemPrefab;


    private List<RectTransform> _slots = new List<RectTransform>();
    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CreateSlots();
    }


    private void CreateSlots()
    {
        _slots = new List<RectTransform>();
        for (int i = 1; i <= _slotsQuantity; i++)
        {
            var instObject = Instantiate
                (new GameObject($"Slot {i}"), transform);

            _slots.Add(instObject.AddComponent<RectTransform>());
        }
    }

    public static void Take(ItemType itemType, Vector3 takePosition)
    {
        var item = Instantiate(instance._inventoryItemPrefab, UI.main);
        item.GetComponent<RectTransform>().position = 
            Camera.main.WorldToScreenPoint(takePosition);

        item.SetType(itemType);

        RectTransform freeSlot = null;
        foreach (var slot in instance._slots)
            if (slot.childCount == 0)
            {
                freeSlot = slot;
                break;
            }

        item.MoveToSlot(freeSlot, onCompleted: 
            () => instance._inventoryItems.Add(item));
    }

    public static void Drop(ItemType itemType, Vector3 dropPosition, Action onDropped)
    {
        InventoryItem item = null;
        foreach (var inventoryItem in instance._inventoryItems)
            if (inventoryItem.type == itemType)
            {
                item = inventoryItem;
                break;
            }

        instance._inventoryItems.Remove(item);
        item.MoveToDrop(dropPosition, onCompleted: () => onDropped?.Invoke());
    }

    public static bool hasFreeSlot
    {
        get
        {
            foreach (var slot in instance._slots)
                if (slot.childCount != 0) return true;

            return false;
        }
    }

    public static bool HasItem(ItemType itemType)
    {
        foreach (var item in instance._inventoryItems)
            if (item.type == itemType) return true;

        return false;
    }





}
