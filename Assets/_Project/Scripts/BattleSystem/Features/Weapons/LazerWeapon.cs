using UnityEngine;

public class LazerWeapon : Weapon
{
    [Space(10)]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private GameObject _damageEffectPrefab;
    [SerializeField] private float _lazerLifetime;

    private float _currentLifetime;

    protected override void HandleShoot(Unit targetUnit)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, _shotPosition.position);
        _lineRenderer.SetPosition(1, targetUnit.Pivot);
        Instantiate(_damageEffectPrefab, targetUnit.Pivot, Quaternion.identity);
        _currentLifetime = _lazerLifetime;

        targetUnit.Health.Damage(Attack.Damage);
    }

    protected override void Update()
    {
        base.Update();

        _currentLifetime -= Time.deltaTime;

        if (_currentLifetime < 0f)
            _lineRenderer.positionCount = 0;
        
    }


}
