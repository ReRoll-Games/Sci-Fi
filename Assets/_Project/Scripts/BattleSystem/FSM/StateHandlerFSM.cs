using UnityEngine;

public abstract class StateHandlerFSM : MonoBehaviour
{

    public virtual void OnEnterState() { }

    public virtual void OnUpdateState() { }

    public virtual void OnExitState() { }


}
