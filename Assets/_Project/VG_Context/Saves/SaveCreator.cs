using System;
using System.Collections.Generic;
using static VG.Saves;


namespace VG
{
    public partial class Saves
    {
        public const int maxBuildingsQuantity = 1;
    }



    public static class SaveCreator
    {

        public static void Create(StartSaveValues startValues)
        {
            new ItemInt(Key_Save.test_count, 0);
            new ItemBool(Key_Save.ads_enabled, true);
            new ItemString(Key_Save.last_time, DateTime.Now.ToString());

            new ItemString(Key_Save.building_data(0), new BuildingData
            {
                buildingType = BuildingType.Center,
                level = 0,
                position = new UnityEngine.Vector3(3f, 0f, 3f),
                state = BuildingState.Upgrade
            }.ToDataString());

            new ItemString(Key_Save.building_process_data(0), new List<ItemPack>
            { 
                new ItemPack{ itemType = ItemType.Coal, quantity = 5 },
            }.ToDataString());


        }


    }
}


