using UnityEngine;
using VG;


public class RecipeProcessing : MonoBehaviour
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
        if (Saves.String[Key_Save.building_process_data(_building.index)].Value == string.Empty)
            return;

        var recipeProcess = Saves.GetRecipeProcess(_building.index);
        bool itemsEnough = ItemsEnough(recipeProcess);

        if (recipeProcess.timeLeft <= 0f && itemsEnough)
        {
            RestartRecipe(ref recipeProcess);
            Saves.SetRecipeProcess(_building.index, recipeProcess);
            return;
        }


        if (itemsEnough)
        {
            recipeProcess.timeLeft -= 1f;
            if (recipeProcess.timeLeft <= 0f)
            {
                CompleteRecipe(ref recipeProcess);

                if (ItemsEnough(recipeProcess))
                    RestartRecipe(ref recipeProcess);
            }

        }
        else recipeProcess.timeLeft = 0f;

        Saves.SetRecipeProcess(_building.index, recipeProcess);
    }

    private void CompleteRecipe(ref RecipeProcess recipeProcess)
    {
        for (int i = 0; i < recipeProcess.inputItems.Count; i++)
        {
            var itemFullness = recipeProcess.inputItems[i];
            itemFullness.quantity -= itemFullness.max;
            recipeProcess.inputItems[i] = itemFullness;
        }

        recipeProcess.outputItem.quantity++;
    }

    private bool ItemsEnough(in RecipeProcess recipeProcess)
    {
        for (int i = 0; i < recipeProcess.inputItems.Count; i++)
            if (recipeProcess.inputItems[i].quantity < recipeProcess.inputItems[i].max)
                return false;

        return true;
    }

    private void RestartRecipe(ref RecipeProcess recipeProcess)
    {
        var recipe = GameResources.GetRecipesConfig(_building.buildingType)
            .GetRecipe(recipeProcess.recipeIndex);

        recipeProcess.timeLeft = recipe.productionTime;
    }


}
