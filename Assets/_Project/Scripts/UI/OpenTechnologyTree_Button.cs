using VG;


public class OpenTechnologyTree_Button : ButtonHandler
{
    
    protected override void OnClick()
    {
        Instantiate(GameResources.GetPanel(PanelType.TechnologyTree), UI.main);
    }
    
}