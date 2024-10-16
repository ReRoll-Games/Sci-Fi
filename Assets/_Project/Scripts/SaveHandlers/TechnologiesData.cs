


using System.Collections.Generic;

namespace VG
{

    public partial class Saves
    {

        public static int GetTechnologyLevel(TechnologyType technologyType)
        {
            var dataString = String[Key_Save.technologies_data].Value;
            string[] technologiesStrings = dataString.Split(',');

            for (int i = 0; i < technologiesStrings.Length; i++)
            {
                var technologyString = technologiesStrings[i];
                if (technologyString.StartsWith($"{technologyType}"))
                {
                    string technologyLevelString = 
                        technologyString.Replace($"{technologyType}_", string.Empty);

                    return int.Parse(technologyLevelString);
                }
            }
            return 0;
        }


        public static void SetTechnologyLevel(TechnologyType technologyType, int level)
        {
            var dataString = String[Key_Save.technologies_data].Value;
            string[] technologiesStrings = dataString.Split(',');

            for (int i = 0; i < technologiesStrings.Length; i++)
            {
                var technologyString = technologiesStrings[i];
                if (technologyString.StartsWith($"{technologyType}"))
                {
                    string technologyLevelString =
                        technologyString.Replace($"{technologyType}_", string.Empty);

                    string newTechnologyString = technologyString
                        .Replace(technologyLevelString, level.ToString());

                    String[Key_Save.technologies_data].Value = dataString.Replace
                        (technologyString, newTechnologyString);
                    return;
                }
            }

            String[Key_Save.technologies_data].Value += $",{technologyType}_{level}";
        }


    }
}


