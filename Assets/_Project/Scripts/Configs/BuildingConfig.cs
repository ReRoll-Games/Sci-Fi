using System.Collections.Generic;
using UnityEngine;
using VG;


[CreateAssetMenu(menuName = "Project/Configs/Building", fileName = "Building")]
public class BuildingConfig : ScriptableObject
{
    [SerializeField] private BuildingType _buildingType;
    [SerializeField] private List<int> _prices;

    public int GetCurrentPrice()
    {
        int buildingAmount = Saves.GetBuildingAmount(_buildingType);
        return _prices[buildingAmount];
    }

}


public static partial class GameResources
{
    public static BuildingConfig GetBuildingConfig(BuildingType buildingType) =>
        Resources.Load<BuildingConfig>($"Configs/Buildings/{buildingType}");


}
