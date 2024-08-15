using UnityEngine;


public class BladeWeapon : MonoBehaviour
{
    [SerializeField] private Transform _bodyPoint;
    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private AnimatorEvents _bodyAnimatorEvents;
    [SerializeField] private string _attackStateName;

    [Header("Stats:")]
    [SerializeField] private float _attackRange;
    [SerializeField] protected float _attackSpread;
    [SerializeField] private int _damage;



    private void OnEnable()
    {
        PlayerInput.onAttack += OnPlayerInputAttack;
        _bodyAnimatorEvents.onEvent += OnBodyAnimatorEvent;
    }

    private void OnDisable()
    {
        PlayerInput.onAttack -= OnPlayerInputAttack;
        _bodyAnimatorEvents.onEvent -= OnBodyAnimatorEvent;

    }


    private void OnBodyAnimatorEvent(AnimatorEvents.EventType eventType)
    {
        if (eventType == AnimatorEvents.EventType.Shoot)
            ApplyAttack();

    }

    


    private void OnPlayerInputAttack()
    {
        _bodyAnimator.Play(_attackStateName);
    }


    private void ApplyAttack()
    {
        for (int i = 0; i < Entity.everybody.Count; i++)
        {
            var entity = Entity.everybody[i];

            if (entity.Has<Health>() && entity.Has<EnemyTag>() && TargetIsReachable(entity))
            {
                entity.Get<Health>().ApplyDamage(new DamageParameters
                {
                    damage = _damage,
                });
            }

        }
    }


    private bool TargetIsReachable(Entity entity)
    {
        Vector3 targetDirection = entity.transform.position - _bodyPoint.position;
        targetDirection.y = 0;

        return Vector3.Distance(_bodyPoint.position, entity.transform.position) < _attackRange
            && Vector3.Angle(_bodyPoint.forward, targetDirection) < _attackSpread;
    }


}
