using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    private static WorldGrid _instance;


    [SerializeField] private Grid _grid;

    private void Awake()
    {
        _instance = this;
    }


    public static Vector2Int GetGridPosition(Vector3 position)
    {
        var gridPosition = _instance._grid.WorldToCell(position);
        return new Vector2Int(gridPosition.x, gridPosition.y);

    }



}
