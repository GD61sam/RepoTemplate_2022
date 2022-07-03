using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] protected CharacterAttributes _attributes;
    [SerializeField] private string _deathAnimationTrigger;

    protected AnimationController _animationController; 

    public float MaxHealth { get; protected set; }
    public float CurrentHealth { get; protected set; }
    public bool IsDead { get; protected set; }

    private void Start()
    {
        _animationController = GetComponent<AnimationController>();

        MaxHealth = _attributes.Health;
        CurrentHealth = MaxHealth;
    }

    public virtual void TryDamage(float damage)
    {
        CurrentHealth -= Mathf.Clamp(damage, 0, MaxHealth);

        if(CurrentHealth == 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        IsDead = true;
        _animationController.SetTrigger(_deathAnimationTrigger);
    }
}
