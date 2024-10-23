using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public delegate void OnDamaged(int damage);

    public event Action onChanged;
    public event OnDamaged onDamaged;
    public event Action onDeath;

    public int Current { get; protected set; }
    public int Max { get; protected set; }

    public bool Alive => Current > 0;

    public void SetHealth(int value)
    {
        Max = Current = value;
        onChanged?.Invoke();
    }


    public void Damage(int damage)
    {
        int totalDamage = Math.Min(damage, Current);
        Current -= totalDamage;

        onDamaged?.Invoke(totalDamage);
        onChanged?.Invoke();

        if (Current == 0) onDeath?.Invoke();
    }

}
