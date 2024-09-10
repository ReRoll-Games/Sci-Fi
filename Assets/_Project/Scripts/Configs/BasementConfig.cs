using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Project/Configs/BasementConfig", fileName = "Basement")]
public class BasementConfig : ScriptableObject
{
    [System.Serializable]
    private struct BasementPlace
    {
        public List<Vector2Int> places;
    }

    [SerializeField] private List<BasementPlace> _placesPerLevel;


    public List<Vector3Int> GetBasementPositions(int basementLevel)
    {
        return null;
    }


}
