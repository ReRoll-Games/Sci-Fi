using System;

public static class GameEvents
{
    public delegate void OnBuildingUpgrade(int buildingIndex);
    public static event OnBuildingUpgrade onBuildingUpgrade;
    public static void BuildingUpgrade(int buildingIndex) 
        => onBuildingUpgrade?.Invoke(buildingIndex);


}
