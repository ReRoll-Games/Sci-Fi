using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Configs/Recipes", fileName = "Recipes")]
public class RecipesConfig : ScriptableObject
{
    [SerializeField] private List<Recipe> _recipes;
    public int RecipeAmount => _recipes.Count;


    public Recipe GetRecipe(int index)
    {
        var recipe = _recipes[index];
        recipe.index = index;
        return recipe;
    }



}
