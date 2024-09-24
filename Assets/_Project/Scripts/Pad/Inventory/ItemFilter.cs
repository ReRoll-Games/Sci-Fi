using System;
using System.Collections.Generic;
using VG;


public static class ItemFilter
{
    public static Action onFilterChanged;
    public static Filter CurrentFilter { get; private set; } = Filter.All;

    public enum Filter { All = 0, Ores = 1, Ingots = 2, Items = 3 }

    public static readonly Dictionary<ItemType, Filter> itemFilters = new Dictionary<ItemType, Filter>
    {
        { ItemType.Coal, Filter.Ores },
        { ItemType.Iron, Filter.Ores },
        { ItemType.IronIngot, Filter.Ingots },
    };


    public static void SetFilter(Filter section)
    {
        CurrentFilter = section;
        onFilterChanged?.Invoke();
    }


    public static List<ItemType> GetFilteredItems()
    {
        if (CurrentFilter == Filter.All) return Key_Save.allItemTypes;

        var items = new List<ItemType>();
        foreach (var itemFilter in itemFilters)
            if (itemFilter.Value == CurrentFilter) items.Add(itemFilter.Key);

        return items;
    }



}
