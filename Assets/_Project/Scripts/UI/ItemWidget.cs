using System.Collections.Generic;
using UnityEngine;
using VG;

public class ItemWidget : MonoBehaviour
{
    [SerializeField] private List<ItemIcon> _itemIcons;

    public void SetItems(List<ItemPack> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            _itemIcons[i].gameObject.SetActive(true);
            _itemIcons[i].SetItemType(items[i].itemType);

            int hasItems = Saves.Int[Key_Save.item_quantity(items[i].itemType)].Value;
            _itemIcons[i].SetQuantity(hasItems, items[i].quantity);

        }
        for (int i = items.Count; i < _itemIcons.Count; i++)
            _itemIcons[i].gameObject.SetActive(false);
    }




}
