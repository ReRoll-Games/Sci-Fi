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
        if (Saves.BuildingHasProcess(_building.index) == false)
            return;

        var productionData = Saves.GetProduction(_building.index);
        var recipe = Saves.GetCurrentRecipe(_building.index);

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

        Saves.SetProduction(_building.index, productionData);
    }

    private bool ItemsEnoughForRecipe(in Recipe recipe)
    {
        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            int hasItemsQuantity = Saves.Int[Key_Save.item_quantity(recipe.inputItems[i].itemType)].Value;
            if (hasItemsQuantity < recipe.inputItems[i].quantity)
                return false;
        }

        return true;
    }

    private void BeginProduction(in Recipe recipe, ref ItemProductionData productionData)
    {
        foreach (var itemPack in recipe.inputItems)
            Saves.Int[Key_Save.item_quantity(itemPack.itemType)].Value -= itemPack.quantity;

        productionData.timeLeft = recipe.productionTime;
    }


}
