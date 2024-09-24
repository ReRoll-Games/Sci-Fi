using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Configs/BuildingPrices", fileName = "BuildingPrices")]
public class BuildingPricesConfig : ScriptableObject
{
    [System.Serializable]
    private struct BuildingPrice
    {
        public BuildingType buildingType;
        public List<int> prices;
    }


    [SerializeField] private List<BuildingPrice> _buildingPrices;



    public int GetPrice(BuildingType buildingType, int buildingAmount)
        => _buildingPrices.Find((buildingPrice) => buildingPrice.buildingType == buildingType)
        .prices[buildingAmount];





}
