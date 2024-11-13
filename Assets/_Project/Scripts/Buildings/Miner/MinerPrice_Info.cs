using UnityEngine;
using UnityEngine.UI;
using VG;

public class MinerPrice_Info : Info
{
    [SerializeField] private Transform _minerTransform;
    [SerializeField] private ItemRequireWidget _itemRequireWidget;
    [SerializeField] private Button _buildButton;

    protected override void Subscribe()
    {
        GameEvents.onInventoryChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        GameEvents.onInventoryChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        var gridPosition = WorldGrid.GetGridPosition(_minerTransform.position);
        ItemType itemType = Configs.GetPlaces().ItemSourcePositions[gridPosition];

        var itemRequire = Configs.GetMiner(itemType).GetPrice(0);
        _itemRequireWidget.SetRequire(itemRequire);

        bool buildAvailable = true;
        foreach (var requiredItemPack in itemRequire)
        {
            int hasItems = Saves.Int[Key_Save.item_amount(requiredItemPack.itemType)].Value;

            if (hasItems < requiredItemPack.amount)
            {
                buildAvailable = false;
                break;
            }
        }

        _buildButton.interactable = buildAvailable;
    }



}
