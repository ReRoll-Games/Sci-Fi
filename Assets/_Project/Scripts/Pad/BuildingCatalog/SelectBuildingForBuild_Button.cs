using UnityEngine;
using VG;


public class SelectBuildingForBuild_Button : ButtonHandler
{
    [SerializeField] private BuildingWidget _buildingWidget;

    protected override void OnClick()
    {
        BuildMode.Enable(_buildingWidget.BuildingType);
        Pad.Close();
    }
    
}