using UnityEngine;


[CreateAssetMenu(menuName = "Project/Item", fileName = "Item")]
public class ItemConfig : ScriptableObject
{
    [field: SerializeField] public ItemDrop ItemDropPrefab;



}

public static partial class GameResources
{
    public static ItemConfig GetItemConfig(ItemType itemType)
        => Resources.Load<ItemConfig>($"Configs/Items/{itemType}");

}