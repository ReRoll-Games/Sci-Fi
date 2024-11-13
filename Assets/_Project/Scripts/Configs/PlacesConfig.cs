using System.Collections.Generic;
using UnityEngine;
using VG;

[CreateAssetMenu(menuName = "Project/Places", fileName = "Places")]
public class PlacesConfig : ScriptableObject
{
    [System.Serializable]
    private struct ItemSource
    {
        public ItemType itemType;
        public GameObject sourcePrefab;
    }

    [System.Serializable]
    private struct BasementData
    {
        public Vector2Int gridPosition;
        public int availableFromLevel;
    }

    [System.Serializable]
    private struct ItemSourceData
    {
        public Vector2Int gridPosition;
        public ItemType itemType;
        public int availableFromLevel;
    }



    [field: SerializeField] public GameObject BasementPrefab { get; private set; }
    [SerializeField] private List<BasementData> _basementPositions;
    [SerializeField] private List<ItemSource> _itemSources;
    [SerializeField] private List<ItemSourceData> _itemSourcePositions;



    public List<Vector2Int> BasementPositions
    {
        get
        {
            var list = new List<Vector2Int>();
            int technologyLevel = Saves.GetTechnologyLevel(TechnologyType.Basement);

            foreach (var basementData in _basementPositions)
                if (basementData.availableFromLevel >= technologyLevel)
                    list.Add(basementData.gridPosition);

            return list;
        }
    }

    public Dictionary<Vector2Int, ItemType> ItemSourcePositions
    {
        get
        {
            var dictionary = new Dictionary<Vector2Int, ItemType>();
            int technologyLevel = Saves.GetTechnologyLevel(TechnologyType.Location);

            foreach (var itemSourceData in _itemSourcePositions)
                if (itemSourceData.availableFromLevel >= technologyLevel)
                    dictionary.Add(itemSourceData.gridPosition, itemSourceData.itemType);

            return dictionary;
        }
    }

    public int GetItemSourceIndex(Vector2Int gridPosition)
    {
        for (int index = 0; index < _itemSourcePositions.Count; index++)
            if (_itemSourcePositions[index].gridPosition == gridPosition)
                return index;

        throw new System.Exception($"Grid position doesn't exist: {gridPosition}");
    }

    public GameObject GetItemSourcePrefab(ItemType itemType)
        => _itemSources.Find((itemSource) => itemSource.itemType == itemType).sourcePrefab;

}


public static partial class Configs
{
    public static PlacesConfig GetPlaces() 
        => Resources.Load<PlacesConfig>("Places");
}
