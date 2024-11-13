using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _iconImage;

    public void SetItems(ItemPack itemPack)
    {
        _nameText.text = itemPack.itemType.ToString();
        _amountText.text = itemPack.amount.ToString();
        _iconImage.sprite = Configs.GetItem(itemPack.itemType).IconSprite;
    }




}
