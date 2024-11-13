using UnityEngine;
using VG;

public class RecipeList : MonoBehaviour
{
    [SerializeField] private RecipeWidget _recipeWidgetPrefab;
    [SerializeField] private LockedRecipeWidget _lockedRecipeWidgetPrefab; 
    [SerializeField] private Transform _recipeContainer;


    private void Start()
    {
        var recipeConfig = Configs.GetRecipesConfig(Building.Current.BuildingType);
        int buildingLevel = Saves.GetBuildingData(Building.Current.Index).level;

        for (int i = 0; i < buildingLevel; i++)
            Instantiate(_recipeWidgetPrefab, _recipeContainer)
                .SetRecipe(recipeConfig.GetRecipe(i));

        if (buildingLevel < recipeConfig.RecipeAmount)
            Instantiate(_lockedRecipeWidgetPrefab, _recipeContainer)
                .SetRecipe(recipeConfig.GetRecipe(buildingLevel));


    }


}