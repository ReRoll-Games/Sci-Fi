using UnityEngine;
using VG;

public class BuildingCatalogAvailable_Info : Info
{
    [SerializeField] private GameObject _openBuildingCatalogButton;

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
        bool catalogAvailable = Saves.GetTechnologyLevel(TechnologyType.Furnace) > 0;
        
        _openBuildingCatalogButton.SetActive(catalogAvailable);
    }
    
}