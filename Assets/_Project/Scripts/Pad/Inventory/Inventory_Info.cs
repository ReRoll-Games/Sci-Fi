using UnityEngine;
using VG;

public class Inventory_Info : Info
{
    [SerializeField] private Selector _filterSelector;
    [SerializeField] private ItemWidget _itemWidgetPrefab;
    [SerializeField] private Transform _container;



    protected override void Subscribe()
    {
        ItemFilter.onFilterChanged += UpdateValue;
        foreach (ItemType itemType in Key_Save.AllItemTypes)
            Saves.Int[Key_Save.item_amount(itemType)].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        ItemFilter.onFilterChanged -= UpdateValue;
        foreach (ItemType itemType in Key_Save.AllItemTypes)
            Saves.Int[Key_Save.item_amount(itemType)].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        _filterSelector.Highlight((int)ItemFilter.CurrentFilter);

        foreach (Transform child in _container)
            Destroy(child.gameObject);

        var filteredItemTypes = ItemFilter.GetFilteredItems();
        for (int i = 0; i < filteredItemTypes.Count; i++)
        {
            ItemType itemType = filteredItemTypes[i];
            int itemAmount = Saves.Int[Key_Save.item_amount(itemType)].Value;

            if (itemAmount > 0 && itemType != ItemType.GearCoins)
            {
                Instantiate(_itemWidgetPrefab, _container).SetItems(new ItemPack
                {
                    amount = itemAmount,
                    itemType = itemType,
                });
            }
        }
    }


    
}