using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VG;

public class Repair_PadPage : Info
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private GameObject _repairDoneButton;
    [SerializeField] private List<ItemIcon> _itemIcons;
    [SerializeField] private List<ItemInputButton> _itemPuts;

    protected override void Subscribe()
    {
        Saves.String[Key_Save.repair_process_data(Building.Current.BuildingType)]
            .onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.repair_process_data(Building.Current.BuildingType)]
            .onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        var repairConfig = Configs.GetRepairConfig(Building.Current.BuildingType);

        _nameText.text = repairConfig.Name;
        _descriptionText.text = repairConfig.Description;
        
        int[] itemAmounts = Saves.GetRepairItemAmounts(Building.Current.BuildingType);

        bool repairDone = true;
        for (int i = 0; i < itemAmounts.Length; i++)
        {
            var itemRequire = repairConfig.ItemRequires[i];

            if (itemRequire.amount != itemAmounts[i]) 
                repairDone = false;

            _itemIcons[i].SetItemType(itemRequire.itemType);
            _itemIcons[i].SetAmount(amount: itemAmounts[i], max: itemRequire.amount);
            _itemPuts[i].SetItemRequire(new ItemPack {
                itemType = itemRequire.itemType,
                amount = itemRequire.amount - itemAmounts[i]
            });
        }

        _repairDoneButton.SetActive(repairDone);
    }


}
