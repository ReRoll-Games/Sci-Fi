using UnityEngine;
using VG;

public class BuildMode : MonoBehaviour
{
    private static BuildMode instance;

    [SerializeField] private Grid _grid;
    [SerializeField] private Transform _playerTransform;


    private bool _modeEnabled = false;
    private Building _currentBuilding;


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
        instance._currentBuilding.transform.position = position;
    }


    public static void Enable(BuildingType buildingType)
    {
        var buildingPrefab = GameResources.GetBuildingPrefab(buildingType, 0);
        Vector3 position = instance.GetGridCenterPosition(instance._playerTransform.position);
        instance._currentBuilding = Instantiate(buildingPrefab, position, Quaternion.identity);
    }

    public static void ApplyBuild()
    {
        Saves.SetBuildingData(new BuildingData
        {
            buildingType = instance._currentBuilding.buildingType,
            index = Saves.GetBuildingQuantity(),
            level = 0,
            state = BuildingState.Upgrade,
            gridPosition = instance._grid.WorldToCell(instance._currentBuilding.transform.position)
        });

        instance._modeEnabled = false;
    }


    public static void Disable()
    {
        Destroy(instance._currentBuilding.gameObject);
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
