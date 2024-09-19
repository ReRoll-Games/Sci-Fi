using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MiningPositionData
{
    public ItemType itemType;
    public Vector2Int gridPosition;
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


}
