using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _body;

    private void OnEnable()
    {
        PlayerInput.onMove += OnPlayerInputMove;
    }

    private void OnDisable()
    {
        PlayerInput.onMove -= OnPlayerInputMove;
    }


    private void OnPlayerInputMove(Vector2 direction)
    {
        Vector3 direction3D = new Vector3(direction.x, 0f, direction.y);
        _navMeshAgent.velocity = direction3D * _navMeshAgent.speed;
        _body.forward = direction3D.normalized;
    }





}
