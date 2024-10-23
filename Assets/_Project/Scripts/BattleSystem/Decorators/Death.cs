using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private GameObject _deathEffectPrefab;


    private void OnEnable()
    {
        _unit.Health.onDeath += OnDeath;
    }

    private void OnDisable()
    {
        _unit.Health.onDeath -= OnDeath;
    }


    private void OnDeath()
    {
        Instantiate(_deathEffectPrefab, _unit.Pivot, Quaternion.identity);
        Destroy(_unit.gameObject);
    }


}
