using VG;

public class BuyTechnology_Button : ButtonHandler
{
    
    protected override void OnClick()
    {
        TechnologyType technologyType = TechnologyDescription.TechnologyType;
        int level = TechnologyDescription.Level;

        var tecnhologyConfig = Configs.GetTecnhologyConfig(technologyType, level);
        var requiredItems = tecnhologyConfig.RequiredItems;

        bool buyAvailable = true;
        foreach (var requiredItem in requiredItems)
        {
            int itemAmount = Saves.Int[Key_Save.item_amount(requiredItem.itemType)].Value;
            if (itemAmount < requiredItem.amount)
            {
                buyAvailable = false;
                break;
            }
        }

        if (buyAvailable)
        {
            foreach (var requiredItem in requiredItems)
                Saves.Int[Key_Save.item_amount(requiredItem.itemType)].Value -= requiredItem.amount;

            Saves.SetTechnologyLevel(technologyType, level);
            TechnologyDescription.Close();
        }
    }
    
}