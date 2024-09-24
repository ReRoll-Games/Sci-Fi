using System;
using System.Collections.Generic;
using static VG.Saves;


namespace VG
{
    public partial class Saves
    {
        public const int maxBuildingsQuantity = 10;
    }



    public static class SaveCreator
    {

        public static void Create(StartSaveValues startValues)
        {
            new ItemInt(Key_Save.test_count, 0);
            new ItemBool(Key_Save.ads_enabled, true);
            new ItemString(Key_Save.last_time, DateTime.Now.ToString());

            new ItemInt(Key_Save.money, 500);

            foreach (ItemType itemType in Key_Save.allItemTypes)
                new ItemInt(Key_Save.item_amount(itemType), 0);



            for (int i = 0; i < maxBuildingsQuantity; i++)
            {
                if (i == 0)
                {
                    new ItemString(Key_Save.building_data(0), new BuildingData
                    {
                        buildingType = BuildingType.Center,
                        level = 1,
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


            new ItemString(Key_Save.technologies_data, string.Empty);





        }


    }
}


