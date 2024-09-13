using UnityEngine;
using VG;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class RecipeProcess_Info : Info
{
    [SerializeField] private Window _window;
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private ItemIcon _outputItemIcon;
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
        var recipe = GameResources.GetRecipesConfig
            (_window.building.buildingType).GetRecipe(recipeProcess.recipeIndex);

        for (int i = 0; i < recipeProcess.inputItems.Count; i++)
        {
            var inputItem = recipeProcess.inputItems[i];
            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemType(inputItem.itemType);
            _inputItemIcons[i].SetQuantity(inputItem.quantity, inputItem.max);
        }
        for (int i = recipeProcess.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemIcon.SetItemPack(recipeProcess.outputItem);
        _timeText.text = recipeProcess.timeLeft.ToTimeString();
        _progressBar.value = 1f - recipeProcess.timeLeft / recipe.productionTime;
    }
    
}