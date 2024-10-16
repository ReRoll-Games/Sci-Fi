using System;
using UnityEngine;
using VG;

public class CollectItems_Task : Task
{
    private ItemType _requiredItemType;

    public override string Description => $"Собери {MaxPoints} {_requiredItemType}";


    public CollectItems_Task(int index, int reward, string parameters)
    {
        Index = index;
        Reward = reward;

        string[] splitData = parameters.Split('_');

        _requiredItemType = (ItemType)Enum.Parse(typeof(ItemType), splitData[1]);
        MaxPoints = int.Parse(splitData[0]);

        int slot = Saves.GetTaskSlotByIndex(index);
        string saveData = Saves.String[Key_Save.task_data(slot)].Value;

        if (saveData != string.Empty)
            CurrentPoints = Saves.GetTaskPoints(slot);

        else
        {
            CurrentPoints = 0;
            Saves.String[Key_Save.task_data(slot)].Value = ToSaveString();
        }
    }



    public override void Subscribe()
    {
        GameEvents.onItemCollected += OnItemCollected;
    }

    public override void Unsubscribe()
    {
        GameEvents.onItemCollected -= OnItemCollected;
    }
    

    private void OnItemCollected(ItemPack itemPack)
    {
        if (itemPack.itemType == _requiredItemType)
            CurrentPoints = Mathf.Min(CurrentPoints + itemPack.amount, MaxPoints);

        int slot = Saves.GetTaskSlotByIndex(Index);
        Saves.String[Key_Save.task_data(slot)].Value = ToSaveString();
    }

    
}
