using System.Collections.Generic;
using UnityEngine;
using VG;

public class ItemsUpgradeNeed_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private RectTransform _iconContainer;

    private Dictionary<ItemType, ItemIcon> _itemIcons;


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

    private void CreateIcons(List<ItemPack> itemsNeed)
    {
        _itemIcons = new Dictionary<ItemType, ItemIcon>();

        foreach (var itemPack in itemsNeed)
        {
            var itemIconPrefab = GameResources.GetItemIconPrefab();
            var itemIcon = Instantiate(itemIconPrefab, _iconContainer);
            itemIcon.SetItemType(itemPack.itemType);
            _itemIcons.Add(itemPack.itemType, itemIcon);
        }
    }


    
    
    protected override void UpdateValue()
    {
        var itemsNeed = Saves.GetItemsNeedForUpgradeBuilding(_window.building.index);
        if (_itemIcons == null) CreateIcons(itemsNeed);

        foreach (var itemPack in itemsNeed)
            _itemIcons[itemPack.itemType].SetQuantity(itemPack.quantity);

    }




    
}