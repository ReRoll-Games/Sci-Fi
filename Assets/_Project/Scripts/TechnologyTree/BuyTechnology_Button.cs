using VG;

public class BuyTechnology_Button : ButtonHandler
{
    
    protected override void OnClick()
    {
        TechnologyType technologyType = TechnologyDescription.TechnologyType;
        int level = TechnologyDescription.Level;

        var tecnhologyConfig = GameResources.GetTecnhologyConfig(technologyType);
        var requiredItems = tecnhologyConfig.GetRequiredItems(level);

        bool buyAvailable = true;
        foreach (var requiredItem in requiredItems)
        {
            int itemAmount = Saves.Int[Key_Save.item_quantity(requiredItem.itemType)].Value;
            if (itemAmount < requiredItem.quantity)
            {
                buyAvailable = false;
                break;
            }
        }

        if (buyAvailable)
        {
            foreach (var requiredItem in requiredItems)
                Saves.Int[Key_Save.item_quantity(requiredItem.itemType)].Value -= requiredItem.quantity;

            Saves.SetTechnologyLevel(technologyType, level);
            TechnologyDescription.Close();
        }
    }
    
}