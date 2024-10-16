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
        var productionData = Saves.GetProduction(_building.Index);
        var recipe = Saves.GetCurrentRecipe(_building.Index);

        if (ItemsEnoughForRecipe(recipe, ref productionData)) 
            productionData.timeLeft--;

        else productionData.timeLeft = recipe.productionTime;

        if (productionData.timeLeft <= 0)
            MakeProduct(recipe, ref productionData);

        Saves.SetProduction(_building.Index, productionData);
    }

    private bool ItemsEnoughForRecipe(in Recipe recipe, ref ItemProductionData productionData)
    {
        for (int i = 0; i < recipe.inputItems.Count; i++)
            if (productionData.inputItems[i] < recipe.inputItems[i].amount)
                return false;

        return true;
    }

    private void MakeProduct(in Recipe recipe, ref ItemProductionData productionData)
    {
        for (int i = 0; i < recipe.inputItems.Count; i++)
            productionData.inputItems[i] -= recipe.inputItems[i].amount;

        productionData.produced++;
        productionData.timeLeft = recipe.productionTime;
    }




}
