using System;
using System.Collections.Generic;
using System.Diagnostics;


public static class ListItemPackExtension
{
    public static string ToDataString(this List<ItemPack> itemPacks)
    {
        string data = string.Empty;
        for (int i = 0; i < itemPacks.Count; i++)
            data += $"{itemPacks[i].itemType}_{itemPacks[i].quantity},";

        data = data.Remove(data.Length - 1);
        Debug.WriteLine(data);
        return data;
    }
}





namespace VG
{
    public partial class Saves
    {

        public static List<ItemPack> GetItemsNeedForUpgradeBuilding(int buildingIndex)
        {
            string buildingProcessData = 
                String[Key_Save.building_process_data(buildingIndex)].Value;

            if (buildingProcessData == string.Empty) return new List<ItemPack>();

            string[] buildingProcessItemsData = buildingProcessData.Split(',');

            var itemPacks = new List<ItemPack>();
            for (int i = 0; i < buildingProcessItemsData.Length; i++) 
            {
                string[] itemPackData = buildingProcessItemsData[i].Split('_');

                itemPacks.Add(new ItemPack
                {
                    itemType = (ItemType)Enum.Parse(typeof(ItemType), itemPackData[0]),
                    quantity = int.Parse(itemPackData[1])
                });
            }

            return itemPacks;
        }

        public static void SetItemsNeedForUpgradeBuilding(int buildingIndex, List<ItemPack> itemPacks)
            => String[Key_Save.building_process_data(buildingIndex)].Value = itemPacks.ToDataString();



        public static void DropItemToBuildingUpgrade(ItemType itemType, int buildingIndex)
        {
            var itemPacks = GetItemsNeedForUpgradeBuilding(buildingIndex);

            for (int i = 0; i < itemPacks.Count; i++)
                if (itemPacks[i].itemType == itemType)
                {
                    itemPacks[i] = new ItemPack
                    {
                        quantity = itemPacks[i].quantity - 1,
                        itemType = itemType
                    };
                    break;
                }

            bool upgradeCompleted = true;
            
            for (int i = 0; i < itemPacks.Count; i++)
                if (itemPacks[i].quantity > 0)
                {
                    upgradeCompleted = false;
                    break;
                }

            if (upgradeCompleted)
            {
                var buildingData = GetBuildingData(buildingIndex);
                buildingData.level++;
                String[Key_Save.building_process_data(buildingIndex)].Value = string.Empty;
                SetBuildingData(buildingData);
                GameEvents.BuildingUpgrade(buildingIndex);
            }

            else SetItemsNeedForUpgradeBuilding(buildingIndex, itemPacks);
        }


    }
}

