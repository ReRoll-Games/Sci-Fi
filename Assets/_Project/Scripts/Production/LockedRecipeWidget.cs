using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockedRecipeWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _requireText;
    [SerializeField] private Image _outputItemImage;


    public void SetRecipe(Recipe recipe)
    {
        _nameText.text = recipe.Name;
        _requireText.text = $"Необходима плавильня\n{recipe.index + 1} уровня";

        _outputItemImage.sprite = GameResources.GetItemSprite(recipe.outputItem);
    }
}
