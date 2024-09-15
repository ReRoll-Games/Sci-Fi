

namespace VG
{

    public struct ItemProductionData
    {
        public int recipeIndex;
        public int timeLeft;
        public int produced;

        public string ToDataString() => $"{recipeIndex}_{timeLeft}_{produced}";

        public static ItemProductionData Convert(string data)
        {
            string[] splitData = data.Split('_');
            return new ItemProductionData
            {
                recipeIndex = int.Parse(splitData[0]),
                timeLeft = int.Parse(splitData[1]),
                produced = int.Parse(splitData[2])
            };
        }
    }





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
            return GameResources.GetRecipesConfig(buildingType).GetRecipe(recipeIndex);
        }

    }
}

