using UnityEngine;

public class KnifeHit : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _attackFromPoint;

    private void OnEnable()
    {
        PlayerInput.onAttack += OnPlayerAttack;
    }

    private void OnDisable()
    {
        PlayerInput.onAttack -= OnPlayerAttack;
    }




    private void OnPlayerAttack()
    {
        _animator.SetTrigger("hit");
    }

    public void OnWeaponHit_AnimatorCallback()
    {
        for (int i = 0; i < Entity.everybody.Count; i++)
        {
            var entity = Entity.everybody[i];
            if (entity.Has<EnemyTag>() && entity.Has<Health>())
            {
                if (Vector3.Distance(_attackFromPoint.position, entity.transform.position) < _attackRange)
                    entity.Get<Health>().ApplyDamage
                        (new DamageParameters{ damage = _damage });

            }
        }
    }


}
