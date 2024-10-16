using System;
using UnityEngine;
using VG;

public class GameEvents : MonoBehaviour
{
    public delegate void OnBuildingUpgrade(int buildingIndex);
    public static event OnBuildingUpgrade onBuildingUpgrade;
    public static void BuildingUpgrade(int buildingIndex) 
        => onBuildingUpgrade?.Invoke(buildingIndex);

    public static event Action onInventoryChanged;


    private void Awake()
    {
        foreach (var itemType in Key_Save.AllItemTypes)
            Saves.Int[Key_Save.item_amount(itemType)].onChanged += OnInventoryChanged;
    }

    private void OnDestroy()
    {
        foreach (var itemType in Key_Save.AllItemTypes)
            Saves.Int[Key_Save.item_amount(itemType)].onChanged -= OnInventoryChanged;
    }

    private void OnInventoryChanged() => onInventoryChanged?.Invoke();


    public delegate void OnItemCollected(ItemPack itemPack);
    public static event OnItemCollected onItemCollected;

    public static void ItemCollected(ItemPack itemPack) => onItemCollected?.Invoke(itemPack);


}
