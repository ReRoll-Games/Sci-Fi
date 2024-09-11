using UnityEngine;
using VG;


public class ClosePanel_Button : ButtonHandler
{
    [SerializeField] private PanelType _panelType;

    protected override void OnClick() => UI.ClosePanel(_panelType);
    
}