using UnityEngine;
using VG;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class RecipeProcess_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private List<ItemIcon> _itemIcons;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _timeText;


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
        var recipeProcess = Saves.GetRecipeProcess(_window.building.index);



    }
    
}