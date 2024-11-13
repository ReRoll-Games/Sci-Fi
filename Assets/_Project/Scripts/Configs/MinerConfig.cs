using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/MinerPrices", fileName = "MinerPrices")]
public class MinerConfig : ScriptableObject
{
    [System.Serializable]
    private struct Price
    {
        public List<ItemPack> itemPacks;
    }


    [SerializeField] private float _itemsPerHour;
    [SerializeField] private List<Price> _priceList;

    public List<ItemPack> GetPrice(int level) => _priceList[level].itemPacks;


    public float GetItemsPerHour(int level) => _itemsPerHour;


}
public static partial class Configs
{
    public static MinerConfig GetMiner(ItemType itemType) =>
        Resources.Load<MinerConfig>($"Miners/{itemType}");
}