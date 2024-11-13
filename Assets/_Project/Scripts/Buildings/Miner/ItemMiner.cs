using UnityEngine;
using VG;

public class ItemMiner : MonoBehaviour
{
    private int? _index;
    private ItemType? _itemType;

    private MinerConfig _minerConfig;

    public int Index
    {
        get
        {
            _index ??= DefineIndex();
            return (int)_index;
        }
    }

    public ItemType ItemType
    {
        get
        {
            _itemType ??= DefineItemType();
            return (ItemType)_itemType;
        }
    }


    private void Awake()
    {
        _minerConfig = Configs.GetMiner(ItemType);
    }


    private void OnEnable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate += OnOneSecondSpent;
    }


    private void OnDisable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate -= OnOneSecondSpent;
    }

    private ItemType DefineItemType()
    {
        var gridPosition = WorldGrid.GetGridPosition(transform.position);
        return Configs.GetPlaces().ItemSourcePositions[gridPosition];
    }

    private int DefineIndex()
    {
        var gridPosition = WorldGrid.GetGridPosition(transform.position);
        return Configs.GetPlaces().GetItemSourceIndex(gridPosition);
    }
    

    private void OnOneSecondSpent()
    {
        int level = Saves.GetMinerLevel(Index);

        float itemAmount = Saves.GetMinedItems(Index);
        itemAmount += _minerConfig.GetItemsPerHour(level) / 3600f;

        Saves.SetMinedItems(Index, itemAmount);
    }


}
