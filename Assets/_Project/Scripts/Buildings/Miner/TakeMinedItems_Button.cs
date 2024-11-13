using UnityEngine;
using VG;


public class TakeMinedItems_Button : ButtonHandler
{
    [SerializeField] private ItemMiner _miner;

    protected override void OnClick()
    {
        float itemsAmount = Saves.GetMinedItems(_miner.Index);
        Saves.Int[Key_Save.item_amount(_miner.ItemType)].Value += (int)itemsAmount;
        Saves.SetMinedItems(_miner.Index, itemsAmount - (int)itemsAmount);
    }
    
}