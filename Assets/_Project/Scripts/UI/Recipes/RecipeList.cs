using UnityEngine;

public class RecipeList : MonoBehaviour
{
    [SerializeField] private RecipesConfig _recipesConfig;
    [SerializeField] private RecipeWidget _recipeWidgetPrefab;
    [SerializeField] private Transform _recipeContainer;


    private void Start()
    {
        for (int i = 0; i < _recipesConfig.recipes.Count; i++)
            Instantiate(_recipeWidgetPrefab, _recipeContainer)
                .SetRecipe(_recipesConfig.recipes[i], i);
            
    }


}