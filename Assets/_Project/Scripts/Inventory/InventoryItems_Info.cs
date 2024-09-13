using System.Collections.Generic;
using UnityEngine;
using VG;

public class InventoryItems_Info : Info
{
    [SerializeField] private ItemIcon _inventoryCellPrefab;
    [SerializeField] private Transform _cellContainer;

    private Dictionary<ItemType, ItemIcon> _itemIconIntances = new Dictionary<ItemType, ItemIcon>();


    protected override void Subscribe()
    {
        foreach (ItemType itemType in Key_Save.allItemTypes)
            Saves.Int[Key_Save.item_quantity(itemType)].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        foreach (ItemType itemType in Key_Save.allItemTypes)
            Saves.Int[Key_Save.item_quantity(itemType)].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        for (int i = 0; i < Key_Save.allItemTypes.Count; i++)
        {
            ItemType itemType = Key_Save.allItemTypes[i];
            int itemQuantity = Saves.Int[Key_Save.item_quantity(itemType)].Value;

            if (_itemIconIntances.ContainsKey(itemType))
                _itemIconIntances[itemType].SetQuantity(itemQuantity);

            else if (itemQuantity > 0)
            {
                var itemCell = Instantiate(_inventoryCellPrefab, _cellContainer);
                itemCell.SetItemType(itemType);
                itemCell.SetQuantity(itemQuantity);
                _itemIconIntances.Add(itemType, itemCell);
            }
        }


    }
    
}