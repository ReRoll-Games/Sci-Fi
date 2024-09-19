using UnityEngine;
using VG;

public class MinedItems_Info : Info
{
    [SerializeField] private Building _building;

    protected override void Subscribe()
    {
        Saves.String[Key_Save.building_process_data(_building.index)].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data(_building.index)].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        


    }
    
}