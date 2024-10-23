using System.Collections.Generic;
using UnityEngine;

public enum State { Idle, Move, Attack }

public abstract class FSM : MonoBehaviour
{
    [SerializeField] private List<StateHandlerFSM> _idleHandlers;
    [SerializeField] private List<StateHandlerFSM> _moveHandlers;
    [SerializeField] private List<StateHandlerFSM> _attackHandlers;

    protected State CurrentState { get; private set; }
    private List<StateHandlerFSM> _currentStateHandlers;

    private void Start() => SetState(State.Idle);



    protected void SetState(State state)
    {
        if (CurrentState == state) return;

        _currentStateHandlers?.ForEach((handler) => handler.OnExitState());

        switch (state)
        {
            case State.Idle:
                _currentStateHandlers = _idleHandlers;
                break;

            case State.Move:
                _currentStateHandlers = _moveHandlers;
                break;

            case State.Attack:
                _currentStateHandlers = _attackHandlers;
                break;
        }

        _currentStateHandlers.ForEach((handler) => handler.OnEnterState());
        CurrentState = state;
    }


    protected virtual void Update()
    {
        _currentStateHandlers?.ForEach((handler) => handler.OnUpdateState());
    }



}
