using System.Collections.Generic;
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

    private List<Vector2Int> _freeBasementPositions;


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
        => _freeBasementPositions.Contains(gridPosition);



    public static void Enable(BuildingType buildingType)
    {
        instance._currentBuildingType = buildingType;
        var buildModePrefab = Configs.GetBuildModePrefab(buildingType);
        Vector3 position = instance.GetGridCenterPosition(instance._playerTransform.position);
        instance._currentBuildModeUnit = Instantiate(buildModePrefab, position, Quaternion.identity);
        instance._modeEnabled = true;

        instance._freeBasementPositions = Configs.GetPlaces().BasementPositions;
    }

    public static void ApplyBuild()
    {
        var buildingType = instance._currentBuildingType;
        var gridPosition = instance._grid.WorldToCell(instance._currentBuildModeUnit.transform.position);

        BuildNew(buildingType, new Vector2Int(gridPosition.x, gridPosition.y));

        
        int price = Configs.GetBuildingConfig(buildingType).GetCurrentPrice();
        Saves.Int[Key_Save.item_amount(ItemType.GearCoins)].Value -= price;

        Disable();
    }

    public static void BuildNew(BuildingType buildingType, Vector2Int gridPosition)
    {
        int buildingIndex = Saves.GetBuildingQuantity() - 1;

        var buildingData = new BuildingData
        {
            buildingType = buildingType,
            index = buildingIndex,
            level = 1,
            gridPosition = gridPosition,
        };

        Saves.SetBuildingData(buildingData);
        BuildingCreator.InstantiateBuilding(buildingData);
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
