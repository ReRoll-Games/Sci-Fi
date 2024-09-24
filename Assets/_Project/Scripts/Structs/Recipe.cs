using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Recipe
{
    [SerializeField] private string _nameTranslationKey;
    public List<ItemPack> inputItems;
    public ItemType outputItem;
    public int productionTime;
    [HideInInspector] public int index;


    public string Name => _nameTranslationKey;
}
