using UnityEngine;
using VG;


public class ItemProduction : MonoBehaviour
{
    [SerializeField] private Building _building;


    private void OnEnable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate += OnOneSecondSpent;
    }

    private void OnDisable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate -= OnOneSecondSpent;
    }


    private void OnOneSecondSpent()
    {
        if (Saves.BuildingHasProcess(_building.Index) == false)
            return;

        var productionData = Saves.GetProduction(_building.Index);
        var recipe = Saves.GetCurrentRecipe(_building.Index);

        if (productionData.timeLeft == 0)
        {
            if (ItemsEnoughForRecipe(recipe))
                BeginProduction(recipe, ref productionData);
        }
        else
        {
            productionData.timeLeft--;
            if (productionData.timeLeft == 0)
            {
                productionData.produced++;

                if (ItemsEnoughForRecipe(recipe))
                    BeginProduction(recipe, ref productionData);
            }
        }

        Saves.SetProduction(_building.Index, productionData);
    }

    private bool ItemsEnoughForRecipe(in Recipe recipe)
    {
        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            int hasItemsQuantity = Saves.Int[Key_Save.item_amount(recipe.inputItems[i].itemType)].Value;
            if (hasItemsQuantity < recipe.inputItems[i].amount)
                return false;
        }

        return true;
    }

    private void BeginProduction(in Recipe recipe, ref ItemProductionData productionData)
    {
        foreach (var itemPack in recipe.inputItems)
            Saves.Int[Key_Save.item_amount(itemPack.itemType)].Value -= itemPack.amount;

        productionData.timeLeft = recipe.productionTime;
    }


}
