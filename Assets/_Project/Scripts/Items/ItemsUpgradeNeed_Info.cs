using System.Collections.Generic;
using UnityEngine;
using VG;

public class ItemsUpgradeNeed_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private List<ItemIcon> _itemIcons;


    protected override void Subscribe() 
    {
        print($"Subscribe for {_window.Building.name} {_window.Building.Index}");
        _window.Building.onIndexDefined += OnIndexDefined;
        GameEvents.onInventoryChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        _window.Building.onIndexDefined -= OnIndexDefined;
        Saves.String[Key_Save.building_process_data(_window.Building.Index)]
            .onChanged -= UpdateValue;
        GameEvents.onInventoryChanged -= UpdateValue;
    }

    private void OnIndexDefined()
    {
        Saves.String[Key_Save.building_process_data(_window.Building.Index)]
            .onChanged += UpdateValue;
    }

    
    
    protected override void UpdateValue()
    {
        var buildingData = Saves.GetBuildingData(_window.Building.Index);
        var itemsNeed = GameResources.GetBuildingUpgradeConfig
            (buildingData.buildingType).GetItemsForUpgrade(buildingData.level);

        for (int i = 0; i < itemsNeed.Count; i++)
        {
            _itemIcons[i].gameObject.SetActive(true);
            _itemIcons[i].SetItemType(itemsNeed[i].itemType);

            int hasItems = Saves.Int[Key_Save.item_amount(itemsNeed[i].itemType)].Value;
            _itemIcons[i].SetQuantity(hasItems, itemsNeed[i].amount);

        }
        for (int i = itemsNeed.Count; i < _itemIcons.Count; i++)
            _itemIcons[i].gameObject.SetActive(false);

    }




    
}