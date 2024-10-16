using UnityEngine;
using VG;

public class BuildingCatalog_Info : Info
{
    [SerializeField] private GameObject _furnace;
    [SerializeField] private GameObject _drill;



    protected override void Subscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        _furnace.SetActive(Saves.GetTechnologyLevel(TechnologyType.Furnace) >= 1);
        _drill.SetActive(Saves.GetTechnologyLevel(TechnologyType.Drill) >= 1);

    }
    
}