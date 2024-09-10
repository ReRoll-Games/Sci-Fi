using UnityEngine;
using VG;


public class ClosePanel_Button : ButtonHandler
{
    [SerializeField] private GameObject _panel;

    protected override void OnClick()
    {
        Destroy(_panel);
    }
    
}