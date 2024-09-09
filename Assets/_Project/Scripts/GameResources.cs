
using UnityEngine;

public static class GameResources
{

    public static Building GetBuildingPrefab(BuildingType buildingType, int level)
        => Resources.Load<GameObject>($"Prefabs/Buildings/{buildingType}_{level}")
        .GetComponent<Building>();

    public static ItemIcon GetItemIconPrefab()
        => Resources.Load<GameObject>($"Prefabs/UI/ItemIcon")
        .GetComponent<ItemIcon>();


    public static BuildingUpgradeConfig GetBuildingUpgradeConfig(BuildingType buildingType)
        => Resources.Load<BuildingUpgradeConfig>
        ($"Configs/BuildingUpgrade/{buildingType}");


    public static Window GetUpgradeWindowPrefab()
        => Resources.Load<GameObject>($"Prefabs/Windows/Upgrade")
        .GetComponent<Window>();

    public static Window GetBuildingWindowPrefab(BuildingType buildingType)
        => Resources.Load<GameObject>($"Prefabs/Windows/{buildingType}")
        .GetComponent<Window>();

    public static Sprite GetItemIconSprite(ItemType itemType)
        => Resources.Load<Sprite>($"Sprites/ItemIcons/{itemType}");



}
