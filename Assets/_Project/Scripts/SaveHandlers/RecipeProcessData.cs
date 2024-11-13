

public struct ItemProductionData
{
    public int recipeIndex;
    public int timeLeft;
    public int[] inputItems;
    public int produced;

    public string ToDataString()
    {
        string data = string.Empty;

        for (int i = 0; i < inputItems.Length; i++)
            data += $"{inputItems[i]}_";
        data = data.Remove(data.Length - 1);

        data += $",{recipeIndex}_{timeLeft}_{produced}";

        return data;
    }

    public static ItemProductionData Convert(string data)
    {
        string[] splitData = data.Split(',');
        string[] splitInputItemsData = splitData[0].Split('_');
        string[] splitOtherData = splitData[1].Split('_');

        var inputItems = new int[splitInputItemsData.Length];
        for (int i = 0; i < splitInputItemsData.Length; i++)
            inputItems[i] = int.Parse(splitInputItemsData[i]);

        return new ItemProductionData
        {
            inputItems = inputItems,
            recipeIndex = int.Parse(splitOtherData[0]),
            timeLeft = int.Parse(splitOtherData[1]),
            produced = int.Parse(splitOtherData[2])
        };
    }
}


namespace VG
{

    public partial class Saves
    {
        public static bool BuildingHasProcess(int buildingIndex) 
            => String[Key_Save.building_process_data(buildingIndex)].Value != string.Empty;

        public static void SetProcessFree(int buildingIndex)
            => String[Key_Save.building_process_data(buildingIndex)].Value = string.Empty;


        public static void SetProduction(int buildingIndex, ItemProductionData itemProduction)
            => String[Key_Save.building_process_data(buildingIndex)]
            .Value = itemProduction.ToDataString();

        public static ItemProductionData GetProduction(int buildingIndex)
            => ItemProductionData.Convert(String[Key_Save.building_process_data(buildingIndex)].Value);

        public static Recipe GetCurrentRecipe(int buildingIndex)
        {
            BuildingType buildingType = GetBuildingData(buildingIndex).buildingType;
            int recipeIndex = GetProduction(buildingIndex).recipeIndex;
            return Configs.GetRecipesConfig(buildingType).GetRecipe(recipeIndex);
        }

    }
}

