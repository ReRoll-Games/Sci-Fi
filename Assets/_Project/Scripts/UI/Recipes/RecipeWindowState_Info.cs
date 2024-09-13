using UnityEngine;
using VG;

public class RecipeWindowState_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private GameObject _processOff;
    [SerializeField] private GameObject _processOn;



    protected override void Subscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        string processData = Saves.String[Key_Save.building_process_data(_window.building.index)].Value;

        bool processOn = processData != string.Empty;
        _processOff.SetActive(!processOn);
        _processOn.SetActive(processOn);
    }
}
