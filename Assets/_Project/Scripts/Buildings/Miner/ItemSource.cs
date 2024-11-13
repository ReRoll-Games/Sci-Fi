using UnityEngine;
using VG;

public class ItemSource : MonoBehaviour
{
    [SerializeField] private AreaTrigger _areaTrigger;

    private int _index;
    private GameObject _buildModeInstance;
    private Vector2Int _gridPosition;


    private void OnEnable()
    {
        _index = DefineIndex();
        _areaTrigger.onEnter += OnPlayerEnter;
        _areaTrigger.onExit += OnPlayerExit;
        Saves.String[Key_Save.miner_data(_index)].onChanged += OnMinerChanged;
    }

    private void OnDisable()
    {
        _areaTrigger.onEnter -= OnPlayerEnter;
        _areaTrigger.onExit -= OnPlayerExit;
        Saves.String[Key_Save.miner_data(_index)].onChanged -= OnMinerChanged;
    }

    private int DefineIndex()
    {
        var gridPosition = WorldGrid.GetGridPosition(transform.position);
        return Configs.GetPlaces().GetItemSourceIndex(gridPosition);
    }

    private void OnMinerChanged()
    {
        if (Saves.GetMinerLevel(_index) > 0 && _buildModeInstance != null)
            Destroy(_buildModeInstance);
    }

    private void OnPlayerEnter()
    {
        if (Saves.GetMinerLevel(_index) > 0) return;

        var buildingPrefab = Configs.GetBuildingConfig(BuildingType.Miner).BuildModePrefab;
        _buildModeInstance = Instantiate(buildingPrefab, transform.position, Quaternion.identity);
    }

    private void OnPlayerExit()
    {
        if (_buildModeInstance != null) 
            Destroy(_buildModeInstance);
    }

}
