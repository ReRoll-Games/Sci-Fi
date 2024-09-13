using System.Collections.Generic;


[System.Serializable]
public struct Recipe
{
    public List<ItemPack> inputItems;
    public ItemType outputItem;
    public float productionTime;


    public RecipeProcess ToRecipeRrocess(int recipeIndex)
    {
        var itemFullness = new List<ItemFullness>();
        for (int i = 0; i < inputItems.Count; i++)
        {
            itemFullness.Add(new ItemFullness
            {
                itemType = inputItems[i].itemType,
                max = inputItems[i].quantity,
                quantity = 0
            });
        }

        return new RecipeProcess
        {
            inputItems = itemFullness,
            outputItem = new ItemPack
            {
                itemType = outputItem,
                quantity = 0
            },
            recipeIndex = recipeIndex,
            timeLeft = 0f
        };

    }

    
}
