using System.Collections.Generic;
using UnityEngine;
using VG;

public class BuildingCreator : MonoBehaviour
{

    private List<Building> _buildings;




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
        var newBuildingPrefab = GameResources.GetBuildingPrefab
            (buildingData.buildingType, buildingData.level);

        Destroy(_buildings[buildingIndex].gameObject);
        
        var newBuilding = Instantiate(newBuildingPrefab, buildingData.position, Quaternion.identity);
        _buildings[buildingIndex] = newBuilding;
    }


    private void CreateBuildings()
    {
        _buildings = new List<Building>();

        for (int i = 0; i < Saves.maxBuildingsQuantity; i++)
        {
            if (Saves.String[Key_Save.building_data(i)].Value == string.Empty)
                continue;

            var buildingData = Saves.GetBuildingData(i);

            Building buildingPrefab =
                GameResources.GetBuildingPrefab(buildingData.buildingType, buildingData.level);

            var building = Instantiate(buildingPrefab, buildingData.position, Quaternion.identity);
            building.index = i;

            _buildings.Add(building);
        }
    }


    


}
