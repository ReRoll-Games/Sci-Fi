

[System.Serializable]
public struct ItemPack
{
    public ItemType itemType;
    public int quantity;
}


[System.Serializable]
public struct ItemFullness
{
    public ItemType itemType;
    public int quantity;
    public int max;
}
