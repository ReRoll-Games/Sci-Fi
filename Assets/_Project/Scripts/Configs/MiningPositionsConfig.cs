using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MiningPositionData
{
    public Vector2Int gridPosition;
    public ItemType itemType;
}


[CreateAssetMenu(menuName = "Project/Configs/MiningPositions", fileName = "MiningPositions")]
public class MiningPositionsConfig : ScriptableObject
{
    [SerializeField] private List<MiningPositionData> _miningPositions;

    public int positionsQuantity => _miningPositions.Count;

    public MiningPositionData GetMiningPositionData(int index) => _miningPositions[index];


}
