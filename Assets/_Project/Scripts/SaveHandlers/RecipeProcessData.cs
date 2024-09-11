using System;
using System.Collections.Generic;

public struct RecipeProcess
{
    public int recipeIndex;
    public List<ItemFullness> inputItems;
    public ItemPack outputItem;
    public float timeLeft;

    public string ToDataString()
    {
        string dataString = string.Empty;

        dataString += recipeIndex.ToString();

        for (int i = 0; i < inputItems.Count; i++)
            dataString += $"{inputItems[i].quantity}_";

        dataString += $"{outputItem.quantity}_";
        dataString += $"{(int)timeLeft}";

        return dataString;
    }
}




namespace VG
{

    public partial class Saves
    {
        public static void SetRecipeProcess(int buildingIndex, RecipeProcess recipeProcess)
            => String[Key_Save.building_process_data(buildingIndex)].Value = recipeProcess.ToDataString();


        public static RecipeProcess GetRecipeProcess(int buildingIndex)
        {
            var buildingData = GetBuildingData(buildingIndex);
            RecipesConfig recipeConfig = GameResources.GetRecipe(buildingData.buildingType);

            string[] dataArray = String[Key_Save.building_process_data(buildingIndex)]
                .Value.Split('_');


            int recipeIndex = int.Parse(dataArray[0]);
            var recipe = recipeConfig.recipes[recipeIndex];

            var inputItems = new List<ItemFullness>();
            for (int i = 0; i < recipe.inputItems.Count; i++)
            {
                inputItems.Add(new ItemFullness
                {
                    itemType = recipe.inputItems[i].itemType,
                    quantity = int.Parse(dataArray[i + 1]),
                    max = recipe.inputItems[i].quantity
                });
            }

            var outputItemPack = new ItemPack
            {
                quantity = int.Parse(dataArray[dataArray.Length - 2]),
                itemType = recipe.outputItem
            };

            float time = int.Parse(dataArray[dataArray.Length - 1]);

            return new RecipeProcess
            {
                recipeIndex = recipeIndex,
                inputItems = inputItems,
                outputItem = outputItemPack,
                timeLeft = time,
            };
        }



    }
}

