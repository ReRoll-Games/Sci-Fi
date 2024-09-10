

public enum TechnologyState
{
    Done, Available, Locked
}


namespace VG
{

    public partial class Saves
    {

        public static TechnologyState GetTechnologyState(TechnologyType technologyType)
        {
            var dataString = String[Key_Save.technologies_data].Value;
            string[] technologiesStrings = dataString.Split(',');

            for (int i = 0; i < technologiesStrings.Length; i++)
                if (technologiesStrings[i] == technologyType.ToString())
                    return TechnologyState.Done;

            return TechnologyState.Available;
        }


        public static void SetTechnologyDone(TechnologyType technologyType)
        {
            String[Key_Save.technologies_data].Value += $",{technologyType}";
        }


    }
}


