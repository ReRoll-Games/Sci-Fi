using UnityEngine;
using VG;


public class Build_Button : ButtonHandler
{
    [SerializeField] private Building _building;

    protected override void OnClick()
    {
        var gridPosition = WorldGrid.GetGridPosition(_building.transform.position);

        BuildMode.BuildNew(_building.BuildingType, gridPosition);

        if (_building.BuildingType == BuildingType.Miner)
        {
            int index = Configs.GetPlaces().GetItemSourceIndex(gridPosition);
            Saves.SetMinerLevel(index, level: 1);
        }
            
    }
    
}