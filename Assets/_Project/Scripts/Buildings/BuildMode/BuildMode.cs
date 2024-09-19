using System.Linq;
using UnityEngine;
using VG;

public class BuildMode : MonoBehaviour
{
    private static BuildMode instance;

    [SerializeField] private Grid _grid;
    [SerializeField] private Transform _playerTransform;


    private bool _modeEnabled = false;
    private BuildModeUnit _currentBuildModeUnit;
    private BuildingType _currentBuildingType;


    private void Awake()
    {
        instance = this;
    }



    private void Update()
    {
        if (_modeEnabled) HandleBuildMode();
    }


    private void HandleBuildMode()
    {
        Vector3 position = instance.GetGridCenterPosition(instance._playerTransform.position);
        instance._currentBuildModeUnit.transform.position = position;

        var gridPosition = _grid.WorldToCell(position);
        bool buildingAvailable = AvailableForBuilding(new Vector2Int(gridPosition.x, gridPosition.y));

        _currentBuildModeUnit.SetAvailable(buildingAvailable);
    }

    private bool AvailableForBuilding(Vector2Int gridPosition)
    {
        if (_currentBuildingType == BuildingType.Drill)
            return PlaceCreator.MiningPositions.Contains(gridPosition);

        return PlaceCreator.BasementPositions.Contains(gridPosition);
    }


    public static void Enable(BuildingType buildingType)
    {
        instance._currentBuildingType = buildingType;
        var buildModePrefab = GameResources.GetBuildModePrefab(buildingType);
        Vector3 position = instance.GetGridCenterPosition(instance._playerTransform.position);
        instance._currentBuildModeUnit = Instantiate(buildModePrefab, position, Quaternion.identity);
        instance._modeEnabled = true;
    }

    public static void ApplyBuild()
    {
        int buildingIndex = Saves.GetBuildingQuantity() - 1;

        var buildingData = new BuildingData
        {
            buildingType = instance._currentBuildingType,
            index = buildingIndex,
            level = 1,
            state = BuildingState.Active,
            gridPosition = instance._grid.WorldToCell(instance._currentBuildModeUnit.transform.position)
        };

        Saves.SetBuildingData(buildingData);
        BuildingCreator.InstantiateBuilding(buildingData);

        var needItems = 
            GameResources.GetBuildingUpgradeConfig(instance._currentBuildingType);

        Disable();
    }


    public static void Disable()
    {
        Destroy(instance._currentBuildModeUnit.gameObject);
        instance._modeEnabled = false;
    }


    private Vector3 GetGridCenterPosition(Vector3 position)
    {
        Vector3Int gridPosition = _grid.WorldToCell(position);
        Vector3 centerPosition = _grid.GetCellCenterWorld(gridPosition);
        centerPosition.y = BuildingCreator.offsetY;
        return centerPosition;
    }




}
