using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class RecipeWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private List<ItemIcon> _inputItemIcons;
    [SerializeField] private Image _outputItemImage;
    [SerializeField] private Image _arrowImage;
    [SerializeField] private List<Sprite> _arrowSprites;

    public Recipe Recipe { get; private set; }


    public void SetRecipe(Recipe recipe)
    {
        Recipe = recipe;

        _timeText.text = ((float)recipe.productionTime).ToTimeString();
        _nameText.text = recipe.Name;
        _arrowImage.sprite = _arrowSprites[recipe.inputItems.Count - 1];

        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            var itemPack = recipe.inputItems[i];
            _inputItemIcons[i].gameObject.SetActive(true);
            _inputItemIcons[i].SetItemPack(itemPack);
        }
        for (int i = recipe.inputItems.Count; i < _inputItemIcons.Count; i++)
            _inputItemIcons[i].gameObject.SetActive(false);

        _outputItemImage.sprite = Configs.GetItem(recipe.outputItem).IconSprite;
    }


}
