using System.Collections.Generic;
using UnityEngine;
using VG;

public class BasementCreator : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _basementPrefab;


    private List<Vector2Int> _basementInstances = new List<Vector2Int>();


    private void Awake()
    {
        Saves.String[Key_Save.technologies_data].onChanged += UpdateBasement;
    }

    private void OnDestroy()
    {
        Saves.String[Key_Save.technologies_data].onChanged -= UpdateBasement;
    }



    private void UpdateBasement()
    {
        throw new System.NotImplementedException();
    }


    private void Start()
    {
        Vector3 position = _grid.GetCellCenterLocal(new Vector3Int(1, 1, 0));
        Instantiate(_basementPrefab, position, Quaternion.Euler(0f, 30f, 0f));
    }


    private int GetBasementLevel()
    {
        if (Saves.GetTechnologyState(TechnologyType.Basement) == TechnologyState.Done)
            return 1;

        return 0;
    }



}
