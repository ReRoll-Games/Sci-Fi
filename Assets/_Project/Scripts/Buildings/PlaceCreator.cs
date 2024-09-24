using System.Collections.Generic;
using UnityEngine;
using VG;

public class PlaceCreator : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [Header("Basement")]
    [SerializeField] private GameObject _basementPrefab;
    [SerializeField] private BasementConfig _basementConfig;


    public static List<Vector2Int> BasementPositions { get; private set; }
    public static List<Vector2Int> MiningPositions { get; private set; }


    private void Awake()
    {
        BasementPositions = new List<Vector2Int>();
        MiningPositions = new List<Vector2Int>();
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
        UpdateMiningPositions();
    }


    private void UpdateBasement()
    {
        int basementLevel = Saves.GetTechnologyLevel(TechnologyType.Basement);

        foreach (var basementPosition in _basementConfig.GetBasementPositions(basementLevel))
        {
            if (BasementPositions.Contains(basementPosition) == false)
            {
                Vector3 position = _grid.GetCellCenterLocal
                    (new Vector3Int(basementPosition.x, basementPosition.y, 0));
                Instantiate(_basementPrefab, position, Quaternion.Euler(0f, 30f, 0f));
                BasementPositions.Add(basementPosition);
            }
        }
    }


    private void UpdateMiningPositions()
    {
        int miningPositionsLevel = Saves.GetTechnologyLevel(TechnologyType.MiningPositions);

        foreach (var miningPosition in GameResources.MiningPositionsConfig
            .GetMiningPositions(miningPositionsLevel))
        {
            if (MiningPositions.Contains(miningPosition.gridPosition) == false)
            {
                var gridPosition = miningPosition.gridPosition;

                Vector3 position = _grid.GetCellCenterLocal
                    (new Vector3Int(gridPosition.x, gridPosition.y, 0));

                Instantiate(miningPosition.prefab, position, Quaternion.Euler(0f, 30f, 0f));
                MiningPositions.Add(gridPosition);
            }
        }
    }






}
