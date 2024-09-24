using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class ItemProduction_Info : Info
{
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private ItemIcon _outputItemIcon;
    [SerializeField] private Image _progressFill;
    [SerializeField] private TextMeshProUGUI _timeText; 


    protected override void Subscribe()
    {
        Saves.String[Key_Save.building_process_data
            (Building.Current.Index)].onChanged += UpdateValue;
        GameEvents.onInventoryChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.building_process_data
            (Building.Current.Index)].onChanged -= UpdateValue;
        GameEvents.onInventoryChanged -= UpdateValue;
    }


    protected override void UpdateValue()
    {
        var recipe = Saves.GetCurrentRecipe(Building.Current.Index);
        var productionData = Saves.GetProduction(Building.Current.Index);

        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            var inputItem = recipe.inputItems[i];
            int currentQuantity = Saves.Int[Key_Save.item_amount(inputItem.itemType)].Value;

            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemType(inputItem.itemType);
            _inputItemIcons[i].SetQuantity(currentQuantity, inputItem.amount);
        }
        for (int i = recipe.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemIcon.SetItemType(recipe.outputItem);
        _outputItemIcon.SetQuantity(productionData.produced);

        float timeLeft = productionData.timeLeft;
        _progressFill.fillAmount = 1f - timeLeft / recipe.productionTime;

        if (productionData.timeLeft == 0)
            _timeText.gameObject.SetActive(false);
        else
        {
            _timeText.gameObject.SetActive(true);
            _timeText.text = timeLeft.ToTimeString();
        }
    }



    
}