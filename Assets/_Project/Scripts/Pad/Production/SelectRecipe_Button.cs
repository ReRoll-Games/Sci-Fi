using UnityEngine;
using VG;


public class SelectRecipe_Button : ButtonHandler
{
    [SerializeField] private RecipeWidget _recipeWidget;

    protected override void OnClick()
    {
        var recipe = _recipeWidget.Recipe;
        int[] inputItems = new int[recipe.inputItems.Count];
        for (int i = 0; i < inputItems.Length; i++)
            inputItems[i] = 0;


        var itemProduction = new ItemProductionData
        {
            inputItems = inputItems,
            recipeIndex = recipe.index,
            timeLeft = 0,
            produced = 0
        };

        Saves.SetProduction(Building.Current.Index, itemProduction);
        Production_PadPage.SelectSection(Production_PadPage.Section.Process);
    }
    
}