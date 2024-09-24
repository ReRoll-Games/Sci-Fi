using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG;

public class ItemWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _iconImage;

    public void SetItems(ItemPack itemPack)
    {
        _nameText.text = itemPack.itemType.ToString(); //Localization.GetString(Key_Phrase.item(itemPack.itemType));
        _amountText.text = itemPack.amount.ToString();
        _iconImage.sprite = GameResources.GetItemSprite(itemPack.itemType);
    }




}
