using System.Collections.Generic;
using UnityEngine;
using VG;


public class UpgradeBuilding_Button : ButtonHandler
{
    [SerializeField] private Window _window;

    protected override void OnClick()
    {
        var buildingData = Saves.GetBuildingData(_window.building.index);
        var itemsNeed = GameResources.GetBuildingUpgradeConfig
            (buildingData.buildingType).GetItemsForUpgrade(buildingData.level);

        if (UpgradeAvailable(itemsNeed)) ApplyUpgrade(itemsNeed);
    }

    private bool UpgradeAvailable(List<ItemPack> itemsNeed)
    {
        foreach (var itemPack in itemsNeed)
            if (Saves.Int[Key_Save.item_quantity(itemPack.itemType)].Value < itemPack.quantity)
                return false;

        return true;
    }

    private void ApplyUpgrade(List<ItemPack> itemsNeed)
    {
        foreach (var itemPack in itemsNeed)
            Saves.Int[Key_Save.item_quantity(itemPack.itemType)].Value -= itemPack.quantity;

        var buildingData = Saves.GetBuildingData(_window.building.index);
        buildingData.level++;
        buildingData.state = BuildingState.Active;
        Saves.SetBuildingData(buildingData);
        GameEvents.BuildingUpgrade(buildingData.index);
    }


    
}