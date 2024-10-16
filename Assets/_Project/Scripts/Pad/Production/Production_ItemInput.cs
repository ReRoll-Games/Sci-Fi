using VG;

public class Production_ItemInput : ItemInputButton
{
    public override void OnItemInput(ItemPack itemPack)
    {
        var recipe = Saves.GetCurrentRecipe(Building.Current.Index);

        int itemIndex = 0;
        for (int i = 0; i < recipe.inputItems.Count; i++)
            if (itemPack.itemType == recipe.inputItems[i].itemType)
            {
                itemIndex = i;
                break;
            }

        var productionData = Saves.GetProduction(Building.Current.Index);
        productionData.inputItems[itemIndex] += itemPack.amount;

        Saves.SetProduction(Building.Current.Index, productionData);
    }
}
