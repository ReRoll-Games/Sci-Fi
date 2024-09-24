using System;
using UnityEngine;


public class Building : MonoBehaviour
{
    public static Building Current { get; private set; }

    public event Action onIndexDefined;


    [field: SerializeField] public BuildingType BuildingType { get; private set; }
    public int Index { get; private set; }
    public void SetIndex(int index)
    {
        Index = index;
        onIndexDefined?.Invoke();
    }



    public static void SetInteractableBuilding(Building building) 
        => Current = building;


}
