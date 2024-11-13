namespace VG
{
    public partial class Saves
    {

        public static int GetMinerLevel(int index)
            => int.Parse(String[Key_Save.miner_data(index)].Value.Split('_')[0]);


        public static void SetMinerLevel(int index, int level)
        {
            string[] splitData = String[Key_Save.miner_data(index)].Value.Split('_');
            String[Key_Save.miner_data(index)].Value = $"{level}_{splitData[1]}";
        }

        public static float GetMinedItems(int index)
            => float.Parse(String[Key_Save.miner_data(index)].Value.Split('_')[1]);

        public static void SetMinedItems(int index, float amount)
        {
            string[] splitData = String[Key_Save.miner_data(index)].Value.Split('_');
            String[Key_Save.miner_data(index)].Value = $"{splitData[0]}_{amount}";
        }




    }


}
