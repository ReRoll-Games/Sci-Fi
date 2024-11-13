
using UnityEngine;

public static partial class Configs
{


    public static RecipesConfig GetRecipesConfig(BuildingType buildingType)
        => Resources.Load<RecipesConfig>($"Configs/Recipes/{buildingType}");

    public static BuildModeUnit GetBuildModePrefab(BuildingType buildingType)
        => Resources.Load<GameObject>($"Prefabs/BuildMode/{buildingType}").GetComponent<BuildModeUnit>();


    public static GameObject GetPanel(PadPageType panelType)
        => Resources.Load<GameObject>($"Prefabs/Panels/{panelType}");

    public static TecnhologyConfig GetTecnhologyConfig(TechnologyType technologyType, int level)
        => Resources.Load<TecnhologyConfig>($"Configs/Technologies/{technologyType}_{level}");

}
