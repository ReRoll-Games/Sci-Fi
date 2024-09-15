using System.Collections.Generic;
using UnityEngine;
using VG;

public class PlaceCreator : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [Header("Basement")]
    [SerializeField] private GameObject _basementPrefab;
    [SerializeField] private BasementConfig _basementConfig;
    [Header("Mining Positions")]
    [SerializeField] private MiningPositionsConfig _miningPositionConfig;



    public static List<Vector2Int> basementPositions { get; private set; }

    private void Awake()
    {
        basementPositions = new List<Vector2Int>();
        Saves.String[Key_Save.technologies_data].onChanged += UpdateBasement;
    }

    private void OnDestroy()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdateBasement;
    }

    private void Start() => UpdateBasement();


    private void UpdateBasement()
    {
        int basementLevel = Saves.GetTechnologyLevel(TechnologyType.Basement);

        foreach (var basementPosition in _basementConfig.GetBasementPositions(basementLevel))
        {
            if (basementPositions.Contains(basementPosition) == false)
            {
                Vector3 position = _grid.GetCellCenterLocal
                    (new Vector3Int(basementPosition.x, basementPosition.y, 0));
                Instantiate(_basementPrefab, position, Quaternion.Euler(0f, 30f, 0f));
                basementPositions.Add(basementPosition);
            }
        }
    }
}
