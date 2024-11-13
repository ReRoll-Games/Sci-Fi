using UnityEngine;
using UnityEngine.UI;
using VG;

public class MinedItems_Info : Info
{
    [SerializeField] private ItemMiner _miner;
    [SerializeField] private ItemIcon _itemIcon;
    [SerializeField] private Image _progressFill;
    [SerializeField] private Button _takeButton;

    protected override void Subscribe()
    {
        Saves.String[Key_Save.miner_data(_miner.Index)].onChanged += UpdateValue;
    }


    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.miner_data(_miner.Index)].onChanged += UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        float minedItemAmount = Saves.GetMinedItems(_miner.Index);

        _itemIcon.SetItemPack(new ItemPack
        {
            itemType = _miner.ItemType,
            amount = (int)minedItemAmount
        });
        _progressFill.fillAmount = minedItemAmount % 1f;
        _takeButton.interactable = minedItemAmount >= 1f;
    }
    
}