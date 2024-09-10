using System.Collections.Generic;
using UnityEngine;
using VG;

public class BuildingCreator : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    private List<Building> _buildings;

    public const float offsetY = 0.35f;


    private void Awake()
    {
        GameEvents.onBuildingUpgrade += OnBuildingUpgrade;
    }

    private void OnDestroy()
    {
        GameEvents.onBuildingUpgrade -= OnBuildingUpgrade;
    }

    private void Start() => CreateBuildings();



    private void OnBuildingUpgrade(int buildingIndex)
    {
        var buildingData = Saves.GetBuildingData(buildingIndex);

        Destroy(_buildings[buildingIndex].gameObject);
        _buildings[buildingIndex] = InstantiateBuilding(buildingData);
    }


    private void CreateBuildings()
    {
        _buildings = new List<Building>();

        for (int i = 0; i < Saves.maxBuildingsQuantity; i++)
        {
            if (Saves.String[Key_Save.building_data(i)].Value == string.Empty)
                continue;
            var building = InstantiateBuilding(Saves.GetBuildingData(i));
            _buildings.Add(building);
        }
    }


    private Building InstantiateBuilding(BuildingData buildingData)
    {
        Building buildingPrefab =
                GameResources.GetBuildingPrefab(buildingData.buildingType, buildingData.level);

        Vector3 position = _grid.GetCellCenterLocal(buildingData.gridPosition);
        position.y = offsetY;
        var buildingInstance = Instantiate(buildingPrefab, position, Quaternion.identity);
        buildingInstance.index = buildingData.index;
        return buildingInstance;
    }




    


}
