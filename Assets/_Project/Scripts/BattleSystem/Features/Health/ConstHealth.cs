using UnityEngine;

public class ConstHealth : Health
{
    [SerializeField] private int _health;


    private void OnEnable()
    {
        SetHealth(_health);
    }


}
