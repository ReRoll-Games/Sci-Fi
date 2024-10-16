using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class ItemProduction_Info : Info
{
    [SerializeField] private GameObject _noProcessPanel;
    [SerializeField] private GameObject _processPanel;
    [Space(10)]
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private List<ItemInputButton> _inputInputButtons;
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
        if (Saves.BuildingHasProcess(Building.Current.Index) == false)
        {
            _noProcessPanel.SetActive(true);
            _processPanel.SetActive(false);
            return;
        }

        _noProcessPanel.SetActive(false);
        _processPanel.SetActive(true);


        var recipe = Saves.GetCurrentRecipe(Building.Current.Index);
        var productionData = Saves.GetProduction(Building.Current.Index);

        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            var inputItem = recipe.inputItems[i];

            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemType(inputItem.itemType);
            _inputItemIcons[i].SetAmount(productionData.inputItems[i], recipe.inputItems[i].amount);

            _inputInputButtons[i].SetItemRequire(new ItemPack
            {
                itemType = inputItem.itemType,
                amount = Saves.Int[Key_Save.item_amount(inputItem.itemType)].Value
            });
        }
        for (int i = recipe.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemIcon.SetItemType(recipe.outputItem);
        _outputItemIcon.SetAmount(productionData.produced);

        float timeLeft = productionData.timeLeft;
        _progressFill.fillAmount = 1f - timeLeft / recipe.productionTime;

        if (productionData.timeLeft == recipe.productionTime)
            _timeText.gameObject.SetActive(false);
        else
        {
            _timeText.gameObject.SetActive(true);
            _timeText.text = timeLeft.ToTimeString();
        }
    }



    
}