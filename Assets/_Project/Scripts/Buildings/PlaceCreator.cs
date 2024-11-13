using System.Collections.Generic;
using UnityEngine;
using VG;

public class PlaceCreator : MonoBehaviour
{
    [SerializeField] private Grid _grid;

    private PlacesConfig _config;

    private static List<Vector2Int> _basementPositions = new List<Vector2Int>();
    private static Dictionary<Vector2Int, ItemType> _itemSourcePositions = new Dictionary<Vector2Int, ItemType>();


    private void Awake()
    {
        _config = Configs.GetPlaces();
        Saves.String[Key_Save.technologies_data].onChanged += UpdatePlaces;
    }

    private void OnDestroy()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdatePlaces;
    }

    private void Start() => UpdatePlaces();
 


    private void UpdatePlaces()
    {
        UpdateBasement();
        UpdateItemSourcePositions();
    }


    private void UpdateItemSourcePositions()
    {
        foreach (var itemSourcePosition in _config.ItemSourcePositions)
        {
            if (_itemSourcePositions.ContainsKey(itemSourcePosition.Key) == false)
            {
                Vector3 position = _grid.GetCellCenterLocal
                    (new Vector3Int(itemSourcePosition.Key.x, itemSourcePosition.Key.y, 0));

                var prefab = _config.GetItemSourcePrefab(itemSourcePosition.Value);

                Instantiate(prefab, position, Quaternion.Euler(0f, 30f, 0f));
                _itemSourcePositions.Add(itemSourcePosition.Key, itemSourcePosition.Value);
            }
        }
    }



    private void UpdateBasement()
    {
        foreach (var basementPosition in _config.BasementPositions)
        {
            if (_basementPositions.Contains(basementPosition) == false)
            {
                Vector3 position = _grid.GetCellCenterLocal
                    (new Vector3Int(basementPosition.x, basementPosition.y, 0));
                Instantiate(_config.BasementPrefab, position, Quaternion.Euler(0f, 30f, 0f));
                _basementPositions.Add(basementPosition);
            }
        }
    }








}
