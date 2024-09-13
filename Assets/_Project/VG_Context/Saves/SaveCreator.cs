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

            new ItemInt(Key_Save.techno_coins, 500);

            foreach (ItemType itemType in Key_Save.allItemTypes)
                new ItemInt(Key_Save.item_quantity(itemType), 0);



            for (int i = 0; i < maxBuildingsQuantity; i++)
            {
                if (i == 0)
                {
                    new ItemString(Key_Save.building_data(0), new BuildingData
                    {
                        buildingType = BuildingType.Center,
                        level = 0,
                        gridPosition = new UnityEngine.Vector3Int(1, 1, 0),
                        state = BuildingState.Upgrade
                    }.ToDataString());

                    new ItemString(Key_Save.building_process_data(0), new List<ItemPack>
                    {
                        new ItemPack{ itemType = ItemType.Coal, quantity = 5 },
                    }.ToDataString());
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


