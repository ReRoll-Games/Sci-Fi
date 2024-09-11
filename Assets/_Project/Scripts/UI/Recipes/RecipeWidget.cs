using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VG;

public class RecipeWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private ItemIcon _outputItemIcon;


    public void SetRecipe(Recipe recipe)
    {
        _timeText.text = recipe.productionTime.ToTimeString();

        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            var itemPack = recipe.inputItems[i];
            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemPack(itemPack);
        }
        for (int i = recipe.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemIcon.SetItemType(recipe.outputItem);
    }


}
