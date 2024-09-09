using UnityEngine;
using VG;


public class Building : MonoBehaviour
{
    public static Building currentBuilding { get; private set; }

    [field: SerializeField] public BuildingType buildingType { get; private set; }
    public int index { get; set; }

    [SerializeField] private AreaTrigger _areaTrigger;

    private Window _currentWindow;
    private bool _playerInsideArea = false;


    private void OnEnable()
    {
        _areaTrigger.onEnter += OnAreaEnter;
        _areaTrigger.onExit += OnAreaExit;
    }

    private void OnDisable()
    {
        _areaTrigger.onEnter -= OnAreaEnter;
        _areaTrigger.onExit -= OnAreaExit;
    }

    private void OnAreaExit()
    {
        if (!_playerInsideArea) return;

        _playerInsideArea = false;
        _currentWindow.Close();
    }

    private void OnAreaEnter()
    {
        if (_playerInsideArea) return;

        _playerInsideArea = true;
        currentBuilding = this;

        var window = GetWindowPrefab();
        _currentWindow = Instantiate(window, transform);
        _currentWindow.Open();
    }



    private Window GetWindowPrefab()
    {
        var buildingData = Saves.GetBuildingData(index);

        if (buildingData.state == BuildingState.Upgrade)
            return GameResources.GetUpgradeWindowPrefab();

        return GameResources.GetBuildingWindowPrefab(buildingType);
    }






}
