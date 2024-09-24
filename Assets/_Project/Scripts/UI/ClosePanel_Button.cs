using UnityEngine;
using VG;


public class ClosePanel_Button : ButtonHandler
{
    [SerializeField] private PadPageType _panelType;

    protected override void OnClick() => UI.ClosePanel(_panelType);
    
}