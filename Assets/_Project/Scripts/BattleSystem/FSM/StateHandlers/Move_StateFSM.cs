using UnityEngine;

public class Move_StateFSM : StateHandlerFSM
{
    [SerializeField] private Unit _unit;
    [SerializeField] private StalkNearestFSM _fsm;

    public override void OnEnterState()
    {
        _unit.Move.NavMeshAgent.isStopped = false;
    }

    public override void OnUpdateState()
    {
        _unit.Move.NavMeshAgent.SetDestination(_fsm.StalkableUnit.Position3D);
    }


}
