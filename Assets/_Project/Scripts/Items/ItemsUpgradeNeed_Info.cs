using System.Collections.Generic;
using UnityEngine;
using VG;

public class ItemsUpgradeNeed_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private List<ItemIcon> _itemIcons;


    protected override void Subscribe() 
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)].onChanged += UpdateValue;
        GameEvents.onInventoryChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)].onChanged -= UpdateValue;
        GameEvents.onInventoryChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        var itemsNeed = Saves.GetItemsNeedForUpgradeBuilding(_window.building.index);

        for (int i = 0; i < itemsNeed.Count; i++)
        {
            _itemIcons[i].gameObject.SetActive(true);
            _itemIcons[i].SetItemType(itemsNeed[i].itemType);

            int hasItems = Saves.Int[Key_Save.item_quantity(itemsNeed[i].itemType)].Value;
            _itemIcons[i].SetQuantity(hasItems, itemsNeed[i].quantity);

        }
        for (int i = itemsNeed.Count; i < _itemIcons.Count; i++)
            _itemIcons[i].gameObject.SetActive(false);

    }




    
}