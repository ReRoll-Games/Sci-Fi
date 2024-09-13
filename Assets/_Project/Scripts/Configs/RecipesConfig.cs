using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Configs/Recipes", fileName = "Recipes")]
public class RecipesConfig : ScriptableObject
{
    [field: SerializeField] public List<Recipe> recipes {  get; private set; }


    public Recipe GetRecipe(int index) => recipes[index];



}
