using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    public ItemType itemType { get; private set; }
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _quantityText;


    public void SetItemType(ItemType itemType)
    {
        this.itemType = itemType;
        _iconImage.sprite = GameResources.GetItemIconSprite(itemType);
    }

    public void SetQuantity(int quantity) => _quantityText.text = quantity.ToString();
    public void SetQuantity(int quantity, int max) => _quantityText.text = $"{quantity}/{max}";


    public void SpringAnimation()
    {

    }

    public void FadeAnimation()
    {

    }


}
