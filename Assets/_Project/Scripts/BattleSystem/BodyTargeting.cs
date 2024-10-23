using UnityEngine;

public class BodyTargeting : MonoBehaviour
{
    [SerializeField] private Transform _bodyTransform;
    [SerializeField] private Transform _handTransform;




    public void TargetToPosition(Vector3 position)
    {
        Vector3 direction = position - _bodyTransform.position;

        _bodyTransform.forward = new Vector3(direction.x, 0f, direction.z).normalized;
        _handTransform.forward = direction.normalized;
    }



}
