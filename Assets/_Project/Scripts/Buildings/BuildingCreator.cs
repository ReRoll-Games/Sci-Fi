using System.Collections.Generic;
using UnityEngine;
using VG;

public class BuildingCreator : MonoBehaviour
{
    private static BuildingCreator instance;

    public static List<Vector2Int> buildingPositions { get; private set; }


    [SerializeField] private Grid _grid;
    private List<Building> _buildings;

    public const float offsetY = 0.35f;


    private void Awake()
    {
        instance = this;
        buildingPositions = new List<Vector2Int>();
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
        InstantiateBuilding(buildingData);
    }

     
    private void CreateBuildings()
    {
        _buildings = new List<Building>();

        for (int i = 0; i < Saves.maxBuildingsQuantity; i++)
        {
            if (Saves.String[Key_Save.building_data(i)].Value == string.Empty)
                continue;

            InstantiateBuilding(Saves.GetBuildingData(i));
        }
    }


    public static Building InstantiateBuilding(BuildingData buildingData)
    {
        Building buildingPrefab =
                GameResources.GetBuildingPrefab(buildingData.buildingType, buildingData.level);

        Vector3 position = instance._grid.GetCellCenterLocal(buildingData.gridPosition3D);
        position.y = offsetY;
        var buildingInstance = Instantiate(buildingPrefab, position, Quaternion.identity);
        buildingInstance.SetIndex(buildingData.index);
        buildingPositions.Add(new Vector2Int(buildingData.gridPosition.x, buildingData.gridPosition.y));

        if (buildingData.index < instance._buildings.Count)
            instance._buildings[buildingData.index] = buildingInstance;

        else instance._buildings.Add(buildingInstance);


        return buildingInstance;
    }




    


}
