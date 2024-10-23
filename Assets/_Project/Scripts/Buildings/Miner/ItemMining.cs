using UnityEngine;
using VG;

public class ItemMining : MonoBehaviour
{
    [SerializeField] private Building _building;


    private void OnEnable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate += OnOneSecondSpent;
    }

    private void OnDisable()
    {
        Repeater.handlers[Key_Repeat.one_second].onUpdate -= OnOneSecondSpent;
    }


    private void OnOneSecondSpent()
    {
        if (Saves.BuildingHasProcess(_building.Index) == false)
            return;

        
    }


}
