using UnityEngine;

public class StalkNearestFSM : FSM
{
    [SerializeField] private Unit _unit;
    public Unit StalkableUnit { get; private set; }



    protected override void Update()
    {
        if (StalkableUnit == null)
            StalkableUnit = FindStalkableUnit();

        if (StalkableUnit == null) { SetState(State.Idle); return; }


        float distance = Vector2.Distance(_unit.Position2D, StalkableUnit.Position2D);

        switch (CurrentState)
        {
            case State.Idle:
                SetState(State.Move);
                break;

            case State.Move:
                if (distance < _unit.Weapon.Attack.MinMaxDistance.x)
                    SetState(State.Attack);
                break;

            case State.Attack:
                if (distance > _unit.Weapon.Attack.MinMaxDistance.y)
                    SetState(State.Move);
                break;
        }

        base.Update();
    }

    private Unit FindStalkableUnit()
    {
        foreach (var unit in Unit.all)
            if (unit.Team.TeamType == _unit.Team.RivalTeam)
                return unit;

        return null;
    }






}
