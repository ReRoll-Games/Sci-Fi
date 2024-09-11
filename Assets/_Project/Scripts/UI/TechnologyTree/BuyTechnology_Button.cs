using UnityEngine;
using VG;


public class BuyTechnology_Button : ButtonHandler
{
    [SerializeField] private TechnologyNode_Info _technologyNodeInfo;

    protected override void OnClick()
    {
        var tecnhologyConfig = GameResources
            .GetTecnhologyConfig(_technologyNodeInfo.technologyType);

        if (Saves.Int[Key_Save.techno_coins].Value >= tecnhologyConfig.price)
        {
            Saves.SetTechnologyLevel(_technologyNodeInfo.technologyType, _technologyNodeInfo.level);
            Saves.Int[Key_Save.techno_coins].Value -= tecnhologyConfig.price;
        }

        
    }
    
}