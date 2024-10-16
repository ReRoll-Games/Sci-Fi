using VG;
using UnityEngine;


public class OpenPadPage_Button : ButtonHandler
{
    [SerializeField] private PadPageType _padPage;

    protected override void OnClick() => Pad.OpenPage(_padPage);

    
}