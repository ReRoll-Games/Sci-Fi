using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using VG;

public class ItemRequireWidget : MonoBehaviour
{
    [SerializeField] private List<ItemIcon> _itemIcons;


    public void SetRequire(List<ItemPack> itemPacks)
    {
        for (int i = 0; i < itemPacks.Count; i++)
        {
            var itemIcon = _itemIcons[i];

            itemIcon.gameObject.SetActive(true);
            itemIcon.SetItemType(itemPacks[i].itemType);

            int hasItems = Saves.Int[Key_Save.item_amount(itemPacks[i].itemType)].Value;
            itemIcon.SetAmount(hasItems, itemPacks[i].amount);

        }
        for (int i = itemPacks.Count; i < 3; i++)
            _itemIcons[i].gameObject.SetActive(false);
    }



}
