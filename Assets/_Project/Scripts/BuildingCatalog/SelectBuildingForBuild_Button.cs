using UnityEngine;
using VG;


public class SelectBuildingForBuild_Button : ButtonHandler
{
    [SerializeField] private BuildingType _buildingType;

    protected override void OnClick()
    {
        BuildMode.Enable(_buildingType);
        UI.ClosePanel(PanelType.BuildingCatalog);
    }
    
}