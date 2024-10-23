using UnityEngine;



public abstract class WeaponAttack : MonoBehaviour
{
    public int Damage { get; protected set; }
    public Vector2 MinMaxDistance { get; protected set; }

    protected float attackRate;



    public float RechargeTime => 1f / attackRate;


}
