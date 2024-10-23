using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    private Quaternion _rotation;

    private void Start()
    {
        _rotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = _rotation;
    }

}
