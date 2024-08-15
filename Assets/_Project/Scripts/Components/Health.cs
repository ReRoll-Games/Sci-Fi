using System;

public class Health : EntityComponent
{
    public event Action<DamageParameters> onDamageApplied;

    public int _value;


    public void ApplyDamage(DamageParameters damageParameters)
    {
        _value -= damageParameters.damage;
        onDamageApplied?.Invoke(damageParameters);
    }



}
