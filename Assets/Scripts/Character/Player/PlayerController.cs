//COPYRIGHT - Property of Samantha McKinney 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //SERIALIZED FIELDS------------------------
    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private bool _hasThirdPersonCam = false;

    //PRIVATE VARIABLES------------------------
    private CharacterMovement _characterMovement;
    private Vector3 _moveInput;
    private Light _flashLight;

    //PUBLIC VARIABLES-------------------------
    public TransformEvent OnPlayerSpawned;

    //PROPERTIES-------------------------------

    //UNITY METHODS----------------------------
    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _flashLight = GetComponentInChildren<Light>();

        //add inputs and enable them
        PlayerInput input = gameObject.AddComponent<PlayerInput>();
        input.actions = _inputActions;
        input.actions.Enable();

        OnPlayerSpawned?.Invoke(transform);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    private void Update()
    {
        //find input direction
        Vector3 up = Vector3.up;
        Vector3 right = Camera.main.transform.right;
        Vector3 forward = Vector3.Cross(right, up);

        Vector3 movedDirection = forward * _moveInput.y + right * _moveInput.x;
        Debug.DrawRay(transform.position, movedDirection, Color.red);

        _characterMovement.SetMoveDirection(movedDirection);
        _characterMovement.SetLookDirection(_hasThirdPersonCam ? forward : movedDirection);
    }

    //INPUT METHODS----------------------------
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnJump()
    {
        _characterMovement.TryJump();
    }

    public void OnStartSprint()
    {
        _characterMovement.SetIsSprinting(true);
    }

    public void OnStopSprint()
    {
        _characterMovement.SetIsSprinting(false);
    }

    public void OnMeleeAttack()
    {

    }

    public void OnShoot()
    {

    }

    public void OnInteract()
    {

        if (InteractionManager.Current.CurrentInteractableData == null) return;

        InteractionManager.Current.CurrentInteractableData.Interactable.GetComponent<IInteractable>().Interact();
    }

    public void OnFlashLight()
    {
        _flashLight.enabled = !_flashLight.enabled;
    }

    //CUSTOM METHODS---------------------------
}
