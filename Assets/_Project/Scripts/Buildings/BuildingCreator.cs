using System.Collections.Generic;
using UnityEngine;
using VG;

public class BuildingCreator : MonoBehaviour
{
    private static BuildingCreator instance;


    [SerializeField] private Grid _grid;
    private List<Building> _buildings;

    public const float offsetY = 0.35f;


    private void Awake()
    {
        instance = this;
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

        for (int i = 0; i < Saves.maxBuildingsAmount; i++)
        {
            if (Saves.String[Key_Save.building_data(i)].Value == string.Empty)
                continue;

            InstantiateBuilding(Saves.GetBuildingData(i));
        }
    }


    public static Building InstantiateBuilding(BuildingData buildingData)
    {
        var config = Configs.GetBuildingConfig(buildingData.buildingType);

        GameObject buildingPrefab = buildingData.level > 0 ? config.ActivePrefab : config.DestroyedPrefab;

        Vector3 position = instance._grid.GetCellCenterLocal(buildingData.gridPosition3D);
        position.y = offsetY;

        var buildingInstance = Instantiate(buildingPrefab, position, Quaternion.identity)
            .GetComponent<Building>();

        buildingInstance.SetIndex(buildingData.index);

        if (buildingData.index < instance._buildings.Count)
            instance._buildings[buildingData.index] = buildingInstance;

        else instance._buildings.Add(buildingInstance);


        return buildingInstance;
    }




    


}
