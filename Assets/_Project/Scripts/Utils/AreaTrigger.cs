using System;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public event Action onEnter;
    public event Action onExit;

    private void OnTriggerEnter(Collider other)
    {
        onEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onExit?.Invoke();
    }


}
