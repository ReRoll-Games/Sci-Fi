using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MiningPositionData
{
    public List<MiningProportion> miningProportions;
    public Vector2Int gridPosition;
    public GameObject prefab;
    public int availableLevel;
}


[CreateAssetMenu(menuName = "Project/Configs/MiningPositions", fileName = "MiningPositions")]
public class MiningPositionsConfig : ScriptableObject
{
    [SerializeField] private List<MiningPositionData> _miningPositions;

    public int positionsQuantity => _miningPositions.Count;


    public List<MiningPositionData> GetMiningPositions(int level)
    {
        var positions = new List<MiningPositionData>();
        for (int i = 0; i < _miningPositions.Count; i++)
            if (level >= _miningPositions[i].availableLevel) 
                positions.Add(_miningPositions[i]);

        return positions;
    }

    public MiningPositionData GetMiningPositionData(int index) => _miningPositions[index];

    public MiningPositionData GetMiningPositionData(Vector2Int gridPosition)
    {
        for (int i = 0; i < _miningPositions.Count; i++)
            if (gridPosition == _miningPositions[i].gridPosition) 
                return _miningPositions[i];

        throw new System.Exception($"Wrong grid position: {gridPosition}.");
    }



}
