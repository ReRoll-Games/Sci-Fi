using UnityEngine;

public class RecipeList : MonoBehaviour
{
    [SerializeField] private RecipesConfig _recipesConfig;
    [SerializeField] private RecipeWidget _recipeWidgetPrefab;
    [SerializeField] private Transform _recipeContainer;


    private void Start()
    {
        foreach (var recipe in _recipesConfig.recipes)
            Instantiate(_recipeWidgetPrefab, _recipeContainer).SetRecipe(recipe);
    }


}