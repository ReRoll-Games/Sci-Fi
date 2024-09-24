

[System.Serializable]
public struct ItemPack
{
    public ItemType itemType;
    public int amount;

    public ItemPackFloat ToFloat() 
        => new ItemPackFloat { itemType = itemType, amount = amount };
}

[System.Serializable]
public struct ItemPackFloat
{
    public ItemType itemType;
    public float amount;

    public ItemPack ToInt()
        => new ItemPack { itemType = itemType, amount = (int)amount };
}


[System.Serializable]
public struct ItemFullness
{
    public ItemType itemType;
    public int amount;
    public int max;
}
