using UnityEngine;

public class ConstWeaponAttack : WeaponAttack
{
    [SerializeField] private int _damage;
    [SerializeField] private Vector2 _minMaxDistance;
    [SerializeField] private float _attackRate;


    private void OnEnable()
    {
        Damage = _damage;
        MinMaxDistance = _minMaxDistance;
        attackRate = _attackRate;
    }

}

