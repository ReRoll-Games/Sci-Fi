using UnityEngine;
using UnityEngine.AI;

public abstract class Move : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }

    public void SetMoveSpeed(float value)
    {
        NavMeshAgent.speed = value;
    }

}
