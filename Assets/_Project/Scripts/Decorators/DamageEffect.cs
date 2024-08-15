using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private float _effectDuration;

    private Material _originMaterial;

    private bool effectApplied => _meshRenderer.material == _damageMaterial;


    private void OnEnable()
    {
        _health.onDamageApplied += OnDamageApplied;
        _originMaterial = _meshRenderer.material;
    }

    private void OnDisable()
    {
        _health.onDamageApplied -= OnDamageApplied;
    }


    private void OnDamageApplied(DamageParameters damageParameters)
    {
        if (!effectApplied) StartCoroutine(ApplyDamageEffect());
    }



    private IEnumerator ApplyDamageEffect()
    {
        _meshRenderer.material = _damageMaterial;
        yield return new WaitForSeconds(_effectDuration);
        _meshRenderer.material = _originMaterial;
    }


}
