//COPYRIGHT - Property of Samantha McKinney 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //SERIALIZED FIELDS------------------------
    [SerializeField] private float _damptime = 0.1f;
    //PRIVATE VARIABLES------------------------
    //PUBLIC VARIABLES-------------------------
    //PROPERTIES-------------------------------


    //PROTECTED VARIABLES----------------------
    protected CharacterMovement _characterMovement;
    protected Animator _animator;

    //UNITY METHODS----------------------------
    void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetParamiters();
    }

    //CUSTOM METHODS---------------------------
    protected virtual void SetParamiters()
    {       
        float speed = _characterMovement.MoveDirection.magnitude;
        //Vector3 flatVelocity = _characterMovement.Velocity;
        //flatVelocity.y = 0;
        //speed = flatVelocity.magnitude / _characterMovement.Speed;

        _animator.SetFloat("Speed", speed, _damptime, Time.deltaTime);
        _animator.SetBool("IsGrounded", _characterMovement.IsGrounded);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }
}
