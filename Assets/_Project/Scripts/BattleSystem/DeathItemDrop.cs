using System.Collections.Generic;
using UnityEngine;

public class DeathItemDrop : MonoBehaviour
{
    [System.Serializable]
    private struct ItemDropData
    {
        public float probabilityPercentage;
        public ItemType itemType;
        public Vector2Int minMaxAmount;


        public bool RollDrop(out ItemPack itemPack)
        {
            itemPack = new ItemPack();
            bool success = Random.Range(0f, 1f) * 100f < probabilityPercentage;

            if (success)
            {
                itemPack.itemType = itemType;
                itemPack.amount = Random.Range(minMaxAmount.x, minMaxAmount.y + 1);
                return true;
            }
            else return false;
        }
    }

    [SerializeField] private Unit _unit;
    [SerializeField] private DropLine _dropLinePrefab;
    [SerializeField] private List<ItemDropData> _itemDataList;


    private void OnEnable()
    {
        _unit.Health.onDeath += OnUnitDeath;
    }

    private void OnDisable()
    {
        _unit.Health.onDeath -= OnUnitDeath;
    }

    private void OnUnitDeath()
    {
        foreach (var itemData in _itemDataList)
            if (itemData.RollDrop(out var itemPack))
            {
                var position = _unit.Position3D;
                position.y = DropLine.floorPositionY;
                Instantiate(_dropLinePrefab, position, Quaternion.identity)
                    .SetItemPack(itemPack);
            }
        
    }



}
