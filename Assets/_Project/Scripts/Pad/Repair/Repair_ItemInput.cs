using VG;

public class Repair_ItemInput : ItemInputButton
{
    public override void OnItemInput(ItemPack itemPack)
    {
        var repairConfig = GameResources.GetRepairConfig(Building.Current.BuildingType);
        int itemIndex = 0;
        for (int i = 0; i < repairConfig.ItemRequires.Count; i++)
            if (itemPack.itemType == repairConfig.ItemRequires[i].itemType)
            {
                itemIndex = i;
                break;
            }

        int[] currentItems = Saves.GetRepairItemAmounts(Building.Current.BuildingType);
        currentItems[itemIndex] += itemPack.amount;

        Saves.SetRepairItemAmounts(Building.Current.BuildingType, currentItems);
    }
}
