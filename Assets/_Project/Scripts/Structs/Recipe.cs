using System.Collections.Generic;


[System.Serializable]
public struct Recipe
{
    public List<ItemPack> inputItems;
    public ItemType outputItem;
    public int productionTime;
}
