using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Scriptable Object / Attributes / Character"))]
public class CharacterAttributes : ScriptableObject
{
    #region(TITLES)
    //SERIALIZED FIELDS------------------------
    //PRIVATE VARIABLES------------------------
    //PROTECTED VARIABLES----------------------
    //PUBLIC VARIABLES-------------------------
    //PROPERTIES-------------------------------
    //UNITY METHODS----------------------------
    //CUSTOM METHODS---------------------------
    #endregion

    [Header("Health")]
    public float Health = 100;
    public float IsHurtThreshold = 25;

    [Header("Movement")]
    public float MovementSpeed = 10;
    public float AccelerationSpeed = 5;
    public float SprintSpeed = 15;
    public float IsHurtSpeed = 8;

    [Header("Turning")]
    public float TurnSpeed = 6f;
    public float TurnSpeedMultiplier = 1f;

    [Header("Airborne")]
    public float JumpHeight = 2;
    public int JumpAmounts = 2;
    public float Gravity = 10;
    public float AirControl = 0.1f;
    public bool AirTurning = true;

    [Header("Grounding")]
    public float GroundCheckRadius = 0.25f;
    public float GroundCheckStartHeight = 1;
    public float GroundCheckEndHeight = 0.2f;
    public LayerMask GroundCheckMask;
}
