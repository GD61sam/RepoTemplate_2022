using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    public bool IsHurt { get; private set; }

    public override void TryDamage(float damage)
    {
        //update health bar
        //flash red border

        base.TryDamage(damage);

        if (CurrentHealth < _attributes.IsHurtThreshold)
        {
            SetIsHurt(true);
        }
    }

    public void TryHeal(float heal)
    {
        CurrentHealth += Mathf.Clamp(heal, 0, MaxHealth);

        if (CurrentHealth > _attributes.IsHurtThreshold)
        {
            SetIsHurt(false);
        }
    }

    private void SetIsHurt(bool isHurt)
    {
        //Change movement speed
        //activate red border
        //change animations

        IsHurt = true;
    }

    protected override void Death()
    {
        //Activate death screen

        base.Death();
    }
}
