using UnityEngine;
using VG;


public class SelectItemFilter_Selector : SelectorHandler
{
    [SerializeField] private ItemFilter.Filter _itemFilter;

    public override void Select()
    {
        ItemFilter.SetFilter(_itemFilter);
    }
}