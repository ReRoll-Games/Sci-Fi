using UnityEngine;

public class BodyTargeting_StateFSM : StateHandlerFSM
{
    [SerializeField] private StalkNearestFSM _fsm;
    [SerializeField] private BodyTargeting _bodyTargeting;


    public override void OnUpdateState()
    {
        _bodyTargeting.TargetToPosition(_fsm.StalkableUnit.Pivot);
    }


}
