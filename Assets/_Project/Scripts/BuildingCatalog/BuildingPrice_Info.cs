using UnityEngine;
using VG;

public class BuildingPrice_Info : Info
{
    [SerializeField] private BuildingType _buildingType;


    protected override void Subscribe() { }
    
    protected override void Unsubscribe() { }
    
    protected override void UpdateValue()
    {
        int buildingAmount = Saves.GetBuildingAmount(_buildingType);
        int price = GameResources.BuildingPricesConfig.GetPrice(_buildingType, buildingAmount);
        text.text = $"${price}";
    }
    
}