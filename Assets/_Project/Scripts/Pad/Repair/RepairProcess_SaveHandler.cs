namespace VG
{

    public partial class Saves
    {

        public static int[] GetRepairItemAmounts(BuildingType buildingType)
        {
            string data = String[Key_Save.repair_process_data(buildingType)].Value;
            string[] splitData = data.Split(',');
            

            int[] itemAmounts = new int[splitData.Length];
            for (int i = 0; i < splitData.Length; i++)
                itemAmounts[i] = int.Parse(splitData[i]);
                
                

            return itemAmounts;
        }

        public static void SetRepairItemAmounts(BuildingType buildingType, int[] itemAmounts)
        {
            string data = string.Empty;
            for (int i = 0; i < itemAmounts.Length; i++)
                data += $"{itemAmounts[i]},";
            data = data.Remove(data.Length - 1);

            String[Key_Save.repair_process_data(buildingType)].Value = data;
        }





    }

}


