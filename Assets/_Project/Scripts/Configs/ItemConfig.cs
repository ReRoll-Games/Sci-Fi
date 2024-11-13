using UnityEngine;


[CreateAssetMenu(menuName = "Project/Item", fileName = "Item")]
public class ItemConfig : ScriptableObject
{
    [field: SerializeField] public ItemDrop ItemDropPrefab { get; private set; }
    [field: SerializeField] public Sprite IconSprite { get; private set; }



}

public static partial class Configs
{
    public static ItemConfig GetItem(ItemType itemType)
        => Resources.Load<ItemConfig>($"Items/{itemType}");

}