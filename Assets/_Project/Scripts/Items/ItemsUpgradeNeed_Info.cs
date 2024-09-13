using System.Collections.Generic;
using UnityEngine;
using VG;

public class ItemsUpgradeNeed_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private List<ItemIcon> _itemIcons;


    protected override void Subscribe() 
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)]
            .onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)]
            .onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        var itemsNeed = Saves.GetItemsNeedForUpgradeBuilding(_window.building.index);

        for (int i = 0; i < itemsNeed.Count; i++)
        {
            _itemIcons[i].gameObject.SetActive(true);
            _itemIcons[i].SetItemPack(itemsNeed[i]);
        }
        for (int i = itemsNeed.Count; i < _itemIcons.Count; i++)
            _itemIcons[i].gameObject.SetActive(false);

    }




    
}