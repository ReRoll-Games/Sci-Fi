using UnityEngine;
using VG;


public class ShowTechnologyDescription_Button : ButtonHandler
{
    [SerializeField] private TechnologyNode _technologyNode;

    protected override void OnClick()
    {
        TechnologyDescription.Open(_technologyNode.TechnologyType, _technologyNode.Level);
    }
    
}