using System;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    public event Action<EventType> onEvent;
    public enum EventType { Shoot }

    public void Invoke(EventType eventType) => onEvent?.Invoke(eventType);


}
