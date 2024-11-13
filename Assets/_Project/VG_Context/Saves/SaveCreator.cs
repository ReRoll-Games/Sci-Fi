using System;
using static VG.Saves;


namespace VG
{
    public partial class Saves
    {
        public const int maxBuildingsAmount = 10;
        public const int maxMinersAmount = 10;
    }



    public static class SaveCreator
    {

        public static void Create(StartSaveValues startValues)
        {
            new ItemInt(Key_Save.test_count, 0);
            new ItemBool(Key_Save.ads_enabled, true);
            new ItemString(Key_Save.last_time, DateTime.Now.ToString());

            foreach (ItemType itemType in Key_Save.AllItemTypes)
            {
                int amount = 50;
                if (itemType == ItemType.GearCoins) amount = 500;
                new ItemInt(Key_Save.item_amount(itemType), amount);
            }
                



            new ItemString(Key_Save.repair_process_data(BuildingType.Center), "0,0,0");
            new ItemString(Key_Save.repair_process_data(BuildingType.Ship), "0,0,0");



            for (int i = 0; i < maxBuildingsAmount; i++)
            {
                if (i == 0)
                {
                    new ItemString(Key_Save.building_data(0), new BuildingData
                    {
                        buildingType = BuildingType.Center,
                        level = 0,
                        gridPosition = new UnityEngine.Vector2Int(1, 1),
                    }.ToDataString());

                    new ItemString(Key_Save.building_process_data(0), string.Empty);
                }
                else
                {
                    new ItemString(Key_Save.building_data(i), string.Empty);
                    new ItemString(Key_Save.building_process_data(i), string.Empty);
                }
            }

            for (int i = 0; i < maxTaskAmount; i++)
                new ItemString(Key_Save.task_data(i), string.Empty);

            for (int i = 0; i < maxMinersAmount; i++)
                new ItemString(Key_Save.miner_data(i), "0_0");


            new ItemString(Key_Save.technologies_data, "Center_1");





        }


    }
}


