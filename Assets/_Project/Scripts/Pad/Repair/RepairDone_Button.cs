using VG;

public class RepairDone_Button : ButtonHandler
{
    protected override void OnClick()
    {
        HandleRepairDone();
        Pad.Close();
    }


    private void HandleRepairDone()
    {
        switch (Building.Current.BuildingType)
        {
            case BuildingType.Center:
                var buildingData = Saves.GetBuildingData(Building.Current.Index);
                buildingData.level = 1;
                Saves.SetBuildingData(buildingData);
                GameEvents.BuildingUpgrade(buildingData.index);
                break;
        }
    }


}
