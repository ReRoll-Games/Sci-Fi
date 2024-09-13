using System;
using System.Collections.Generic;

namespace VG
{
    public static class Key_Save
    {
        public static string test_count => "test";
        public static string ads_enabled => "ads";
        public static string last_time => "lt";


        public static string techno_coins => "co";
        public static string technologies_data => "tech";

        public static string building_data(int index) => $"b{index}";
        public static string building_process_data(int index) => $"bp{index}";
        public static string item_quantity(ItemType itemType) => $"{itemType}";


        private static List<ItemType> _allItemTypes;
        public static List<ItemType> allItemTypes
        {
            get
            {
                if (_allItemTypes == null)
                {
                    _allItemTypes = new List<ItemType>();
                    foreach (string itemTypeString in Enum.GetNames(typeof(ItemType)))
                        _allItemTypes.Add((ItemType)Enum.Parse(typeof(ItemType), itemTypeString));
                }
                return _allItemTypes;
            }
        }


    }
}



