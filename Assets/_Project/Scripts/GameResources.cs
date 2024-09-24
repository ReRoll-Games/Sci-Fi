
using UnityEngine;

public static class GameResources
{
    public static BuildingPricesConfig BuildingPricesConfig =>
        Resources.Load<BuildingPricesConfig>($"Configs/Common/BuildingPrices");

    public static MiningPositionsConfig MiningPositionsConfig =>
        Resources.Load<MiningPositionsConfig>($"Configs/Common/MiningPositions");




    public static RecipesConfig GetRecipesConfig(BuildingType buildingType)
        => Resources.Load<RecipesConfig>($"Configs/Recipes/{buildingType}");

    public static Building GetBuildingPrefab(BuildingType buildingType, int level)
        => Resources.Load<GameObject>($"Prefabs/Buildings/{buildingType}_{level}")
        .GetComponent<Building>();

    public static BuildModeUnit GetBuildModePrefab(BuildingType buildingType)
        => Resources.Load<GameObject>($"Prefabs/BuildMode/{buildingType}").GetComponent<BuildModeUnit>();


    public static BuildingUpgradeConfig GetBuildingUpgradeConfig(BuildingType buildingType)
        => Resources.Load<BuildingUpgradeConfig>($"Configs/BuildingUpgrade/{buildingType}");


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

    public static TecnhologyConfig GetTecnhologyConfig(TechnologyType technologyType)
        => Resources.Load<TecnhologyConfig>($"Configs/Technologies/{technologyType}");
    
    public static GameObject GetMiningPositionPrefab(ItemType itemType)
        => Resources.Load<GameObject>($"Prefabs/MiningPositions/{itemType}");

}
