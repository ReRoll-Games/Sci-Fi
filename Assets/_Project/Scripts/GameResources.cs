
using UnityEngine;

public static partial class GameResources
{
    public static MiningPositionsConfig MiningPositionsConfig =>
        Resources.Load<MiningPositionsConfig>($"Configs/Common/MiningPositions");




    public static RecipesConfig GetRecipesConfig(BuildingType buildingType)
        => Resources.Load<RecipesConfig>($"Configs/Recipes/{buildingType}");

    public static Building GetBuildingPrefab(BuildingType buildingType, int level)
        => Resources.Load<GameObject>($"Prefabs/Buildings/{buildingType}_{level}")
        .GetComponent<Building>();

    public static BuildModeUnit GetBuildModePrefab(BuildingType buildingType)
        => Resources.Load<GameObject>($"Prefabs/BuildMode/{buildingType}").GetComponent<BuildModeUnit>();

    public static Window GetUpgradeWindowPrefab()
        => Resources.Load<GameObject>($"Prefabs/Windows/Upgrade")
        .GetComponent<Window>();

    public static Window GetBuildingWindowPrefab(BuildingType buildingType)
        => Resources.Load<GameObject>($"Prefabs/Windows/{buildingType}")
        .GetComponent<Window>();

    public static Sprite GetItemSprite(ItemType itemType)
        => Resources.Load<Sprite>($"Sprites/ItemIcons/{itemType}");


    public static GameObject GetPanel(PadPageType panelType)
        => Resources.Load<GameObject>($"Prefabs/Panels/{panelType}");

    public static TecnhologyConfig GetTecnhologyConfig(TechnologyType technologyType, int level)
        => Resources.Load<TecnhologyConfig>($"Configs/Technologies/{technologyType}_{level}");
    
    public static GameObject GetMiningPositionPrefab(ItemType itemType)
        => Resources.Load<GameObject>($"Prefabs/MiningPositions/{itemType}");

}
