//COPYRIGHT - Property of Samantha McKinney 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region(TITLES)

    
    //PROTECTED VARIABLES----------------------
    //PUBLIC VARIABLES-------------------------
    
    #endregion

    //SERIALIZED FIELDS------------------------
    [SerializeField] private string _targetTag = "Player";

    //PRIVATE VARIABLES------------------------
    private CharacterMovement _characterMovement;

    //PROPERTIES-------------------------------
    public GameObject Target { get; private set; }
    public Vector3 TargetPos => Target.transform.position;
    public Vector3 MyPos => transform.position;
    public float DistanceToTarget => Vector3.Distance(TargetPos, MyPos);

    //UNITY METHODS----------------------------
    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag(_targetTag);
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if(DistanceToTarget > 2)
        {
            _characterMovement.MoveTo(TargetPos);
            _characterMovement.SetLookDirection((TargetPos - MyPos).normalized);
        }
        else
        {
            _characterMovement.StopMoving();
        }
    }

    //CUSTOM METHODS---------------------------
}
