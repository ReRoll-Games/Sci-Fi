using UnityEngine;

public class ConstMove : Move
{
    [SerializeField] private float _moveSpeed;

    private void OnEnable()
    {
        SetMoveSpeed(_moveSpeed);
    }


}
