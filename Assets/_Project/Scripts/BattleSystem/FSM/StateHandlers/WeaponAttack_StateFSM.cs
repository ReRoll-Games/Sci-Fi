using UnityEngine;

public class WeaponAttack_StateFSM : StateHandlerFSM
{
    [SerializeField] private Unit _unit;
    [SerializeField] private StalkNearestFSM _fsm;

    public override void OnEnterState()
    {
        _unit.Move.NavMeshAgent.isStopped = true;
    }

    public override void OnUpdateState()
    {
        if (_unit.Weapon.Recharged)
            _unit.Weapon.Shoot(_fsm.StalkableUnit);
            
    }


}
