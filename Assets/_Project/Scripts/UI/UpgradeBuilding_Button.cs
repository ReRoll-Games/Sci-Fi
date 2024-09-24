using System.Collections.Generic;
using UnityEngine;
using VG;


public class UpgradeBuilding_Button : ButtonHandler
{
    [SerializeField] private Window _window;

    protected override void OnClick()
    {
        var buildingData = Saves.GetBuildingData(_window.Building.Index);
        var itemsNeed = GameResources.GetBuildingUpgradeConfig
            (buildingData.buildingType).GetItemsForUpgrade(buildingData.level);

        if (UpgradeAvailable(itemsNeed)) ApplyUpgrade(itemsNeed);
    }

    private bool UpgradeAvailable(List<ItemPack> itemsNeed)
    {
        foreach (var itemPack in itemsNeed)
            if (Saves.Int[Key_Save.item_amount(itemPack.itemType)].Value < itemPack.amount)
                return false;

        return true;
    }

    private void ApplyUpgrade(List<ItemPack> itemsNeed)
    {
        foreach (var itemPack in itemsNeed)
            Saves.Int[Key_Save.item_amount(itemPack.itemType)].Value -= itemPack.amount;

        var buildingData = Saves.GetBuildingData(_window.Building.Index);
        buildingData.level++;
        Saves.SetBuildingData(buildingData);
        GameEvents.BuildingUpgrade(buildingData.index);
    }


    
}