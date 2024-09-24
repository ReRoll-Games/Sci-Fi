using System.Collections.Generic;


namespace VG
{
    public partial class Saves
    {

        public static List<ItemPackFloat> GetMinedItems(int buildingIndex)
        {
            var items = new List<ItemPackFloat>();

            var buildingData = GetBuildingData(buildingIndex);
            var miningData = GameResources.MiningPositionsConfig
                .GetMiningPositionData(buildingData.gridPosition);

            string[] splitData = String[Key_Save.building_process_data(buildingIndex)].Value.Split('_');

            for (int i = 0; i < miningData.miningProportions.Count; i++)
                items.Add(new ItemPackFloat
                {
                    itemType = miningData.miningProportions[i].itemType,
                    amount = float.Parse(splitData[i]),
                });

            return items;
        }

        public static void SetMinedItems(List<ItemPackFloat> items, int buildingIndex)
        {
            string data = string.Empty;
            for (int i = 0; i < items.Count; i++)
                data += $"{items[i].amount}_";

            String[Key_Save.building_process_data(buildingIndex)].Value = data;
        }



    }


}
