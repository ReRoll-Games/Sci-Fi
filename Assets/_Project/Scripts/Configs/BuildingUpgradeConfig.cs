using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Configs/BuildingUpgrade", fileName = "BuildingUpgrade")]
public class BuildingUpgradeConfig : ScriptableObject
{
    [System.Serializable]
    private struct ItemsForUpgrade
    {
        public List<ItemPack> itemPacks;
    }


    [field: SerializeField] public BuildingType buildingType { get; private set; }
    [Space(10)]
    [SerializeField] private List<ItemsForUpgrade> _itemsForUpgrade;




    public List<ItemPack> GetItemsForUpgrade(int currentLevel) 
        => _itemsForUpgrade[currentLevel].itemPacks;



}
