using UnityEngine;
using VG;


public class SelectRecipe_Button : ButtonHandler
{
    [SerializeField] private RecipeWidget _recipeWidget;

    protected override void OnClick()
    {
        var itemProduction = new ItemProductionData
        {
            recipeIndex = _recipeWidget.recipeIndex,
            timeLeft = 0,
            produced = 0
        };

        Saves.SetProduction(Building.interactableBuilding.index, itemProduction);
        UI.ClosePanel(PanelType.FurnaceRecipes);
    }
    
}