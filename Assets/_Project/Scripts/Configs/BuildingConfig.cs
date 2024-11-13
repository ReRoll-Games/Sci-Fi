using System.Collections.Generic;
using UnityEngine;
using VG;


[CreateAssetMenu(menuName = "Project/Configs/Building", fileName = "Building")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private BuildingType _buildingType;

    [field: SerializeField] public GameObject DestroyedPrefab { get; private set; }
    [field: SerializeField] public GameObject BuildModePrefab { get; private set; }
    [field: SerializeField] public GameObject ActivePrefab { get; private set; }


    [SerializeField] private List<int> _prices;

    public int GetCurrentPrice()
    {
        int buildingAmount = Saves.GetBuildingAmount(_buildingType);
        return _prices[buildingAmount];
    }

}


public static partial class Configs
{
    public static BuildingConfig GetBuildingConfig(BuildingType buildingType) =>
        Resources.Load<BuildingConfig>($"Configs/Buildings/{buildingType}");


}
