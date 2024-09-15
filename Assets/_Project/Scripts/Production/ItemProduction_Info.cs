using UnityEngine;
using VG;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ItemProduction_Info : Info
{
    [SerializeField] private Window _window;
    [Space(10)]
    [SerializeField] private GameObject _processOff;
    [SerializeField] private GameObject _processOn;
    [Space(10)]
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private ItemIcon _outputItemIcon;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _timeText;


    protected override void Subscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)]
            .onChanged += UpdateValue;

        GameEvents.onInventoryChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data(_window.building.index)]
            .onChanged -= UpdateValue;

        GameEvents.onInventoryChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        bool processOn = Saves.BuildingHasProcess(_window.building.index);

        _processOff.SetActive(!processOn);
        _processOn.SetActive(processOn);

        if (processOn) UpdateRecipeProcess();
    }


    private void UpdateRecipeProcess()
    {
        var recipe = Saves.GetCurrentRecipe(_window.building.index);
        var productionData = Saves.GetProduction(_window.building.index);

        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            var inputItem = recipe.inputItems[i];
            int currentQuantity = Saves.Int[Key_Save.item_quantity(inputItem.itemType)].Value;

            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemType(inputItem.itemType);
            _inputItemIcons[i].SetQuantity(currentQuantity, inputItem.quantity);
        }
        for (int i = recipe.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemIcon.SetItemType(recipe.outputItem);
        _outputItemIcon.SetQuantity(productionData.produced);

        if (productionData.timeLeft == 0)
        {
            _timeText.gameObject.SetActive(false);
            _progressBar.gameObject.SetActive(false);
        }
        else
        {
            _timeText.gameObject.SetActive(true);
            _progressBar.gameObject.SetActive(true);

            float timeLeft = productionData.timeLeft;
            _timeText.text = timeLeft.ToTimeString();
            _progressBar.value = 1f - timeLeft / recipe.productionTime;
        }

        
    }


    
}