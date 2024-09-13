using UnityEngine;
using VG;


public class SelectRecipe_Button : ButtonHandler
{
    [SerializeField] private RecipeWidget _recipeWidget;

    protected override void OnClick()
    {
        Saves.SetRecipeProcess(Building.interactableBuilding.index, 
            _recipeWidget.recipe.ToRecipeRrocess(_recipeWidget.recipeIndex));

        UI.ClosePanel(PanelType.FurnaceRecipes);
    }
    
}