using VG;
using UnityEngine;


public class OpenPanel_Button : ButtonHandler
{
    [SerializeField] private PadPageType _panelType;

    protected override void OnClick() => UI.OpenPanel(_panelType);

    
}