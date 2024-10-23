using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public WeaponAttack Attack { get; protected set; }


    private float _currentRechargeTime = 0f;
    public bool Recharged => _currentRechargeTime < 0f;

    protected virtual void Update()
    {
        _currentRechargeTime -= Time.deltaTime;
    }

    public void Shoot(Unit targetUnit)
    {
        _currentRechargeTime = Attack.RechargeTime;
        HandleShoot(targetUnit);
    }



    protected abstract void HandleShoot(Unit targetUnit);


}
