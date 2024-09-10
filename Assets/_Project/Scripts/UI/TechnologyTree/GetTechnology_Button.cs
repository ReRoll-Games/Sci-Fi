using UnityEngine;
using VG;


public class GetTechnology_Button : ButtonHandler
{
    [SerializeField] private TechnologyNode_Info _technologyNodeInfo;

    protected override void OnClick()
    {
        var tecnhologyConfig = GameResources
            .GetTecnhologyConfig(_technologyNodeInfo.technologyType);

        if (Saves.Int[Key_Save.techno_coins].Value >= tecnhologyConfig.price)
        {
            Saves.SetTechnologyDone(_technologyNodeInfo.technologyType);
            Saves.Int[Key_Save.techno_coins].Value -= tecnhologyConfig.price;
        }

        
    }
    
}