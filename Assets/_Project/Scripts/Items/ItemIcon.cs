using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _quantityText;
    [SerializeField] private bool _useTransparent = false;


    private const float fadeAlpha = 0.5f;


    public void SetItemType(ItemType itemType)
    {
        _iconImage.sprite = GameResources.GetItemSprite(itemType);
    }

    public void SetAmount(int amount) => _quantityText.text = amount.ToString();
    public void SetAmount(int amount, int max)
    {
        if (_useTransparent)
        {
            float alpha = amount == 0 ? fadeAlpha : 1f;
            _iconImage.color = new Color(1f, 1f, 1f, alpha);
        }

        _quantityText.text = $"{amount}/{max}";
    }

    public void SetItemPack(ItemPack itemPack)
    {
        _iconImage.sprite = GameResources.GetItemSprite(itemPack.itemType);
        _quantityText.text = itemPack.amount.ToString();
    }



}
