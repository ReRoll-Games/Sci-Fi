using VG;


public class DisableBuildMode_Button : ButtonHandler
{
    
    protected override void OnClick()
    {
        BuildMode.Disable();
    }
    
}