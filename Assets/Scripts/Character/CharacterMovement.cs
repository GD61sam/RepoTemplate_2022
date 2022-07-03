//COPYRIGHT - Property of Samantha McKinney 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    #region(TITLES)
    //PROTECTED VARIABLES----------------------
    //PUBLIC VARIABLES-------------------------   
    #endregion
    //SERIALIZED FIELDS------------------------
    public CharacterAttributes MovementAttributes;

    //PRIVATE VARIABLES------------------------
    private Rigidbody _rigidbody;
    private NavMeshAgent _navMeshAgent;

    //PROPERTIES-------------------------------
    public bool IsGrounded { get; private set; } = true;
    public Vector3 MoveDirection { get; private set; }
    public Vector3 LookDirection { get; private set; }
    public bool IsSprinting { get; private set; }
    public Vector3 Velocity => _rigidbody.velocity;
    public float Speed => IsSprinting ? MovementAttributes.SprintSpeed : MovementAttributes.MovementSpeed;
    public Vector3 MyPos => transform.position;

    //UNITY METHODS----------------------------
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        LookDirection = transform.forward;

        //disable navmesh movement
        _navMeshAgent.updatePosition = false;
        _navMeshAgent.updateRotation = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        IsGrounded = CheckGrounded();
    }

    //CUSTOM METHODS---------------------------
    public void SetMoveDirection(Vector3 dir)
    {
        MoveDirection = dir;
    }

    public void SetLookDirection(Vector3 dir)
    {
        if (dir.magnitude < 1f) return;
        LookDirection = dir.Flatten().normalized;
    }

    public void MoveTo(Vector3 position)
    {
        //move to this position
        _navMeshAgent.SetDestination(position);
    }

    public void StopMoving()
    {
        //clear existing path
        _navMeshAgent.ResetPath();
        //clear move direction
        SetMoveDirection(Vector3.zero);
    }

    public void Move()
    {
        //sync navmesh agent with character
        _navMeshAgent.nextPosition = MyPos;

        //use possible navmesh agent path to drive direction of movement
        if (_navMeshAgent.hasPath)
        {
            //find next point on path
            Vector3 point = _navMeshAgent.path.corners[1];
            Vector3 directionToPoint = (point - MyPos).normalized;
            SetMoveDirection(directionToPoint);
        }

        //calculate disired velocity
        Vector3 targetVelocity = MoveDirection * (IsSprinting ? MovementAttributes.SprintSpeed : MovementAttributes.MovementSpeed);
        //calculate difference in velocity
        Vector3 velocityDifference = targetVelocity - _rigidbody.velocity;
        //remove y axis from calculation
        velocityDifference.y = 0f;

        //calculate control
        float control = IsGrounded ? 1f : MovementAttributes.AirControl;

        //calculate acceleration
        Vector3 acceleration;
        acceleration = IsSprinting ? velocityDifference * MovementAttributes.SprintSpeed : velocityDifference * MovementAttributes.MovementSpeed;
        acceleration *= control;

        //apply gravity
        acceleration += Vector3.down * MovementAttributes.Gravity;

        //apply accleration
        _rigidbody.AddForce(acceleration);

        Look();
    }

    public void Look()
    {
        if (IsGrounded || MovementAttributes.AirTurning)
        {
            Quaternion targetRotation = Quaternion.LookRotation(LookDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * MovementAttributes.TurnSpeed * MovementAttributes.TurnSpeedMultiplier);
            _rigidbody.MoveRotation(rotation);
        }
    }

    public void TryJump()
    {
        if (IsGrounded)
        {
            //get our jump velocity
            float jumpVelocity = Mathf.Sqrt(2f * MovementAttributes.Gravity * MovementAttributes.JumpHeight);

            //get current velocity and apply jump velocity to Y axis
            Vector3 velocity = _rigidbody.velocity;
            velocity.y = jumpVelocity;
            _rigidbody.velocity = velocity;
            Debug.Log(velocity);
        }
    }

    public bool CheckGrounded()
    {
        Vector3 start = transform.position + transform.up * MovementAttributes.GroundCheckStartHeight;
        Vector3 end = transform.position + transform.up * MovementAttributes.GroundCheckEndHeight;

        float distance = Vector3.Distance(start, end);

        if (Physics.SphereCast(start, MovementAttributes.GroundCheckRadius, Vector3.down, out RaycastHit hitInfo, distance, MovementAttributes.GroundCheckMask))
        {
            return true;
        }

        return false;
    }

    public void SetIsSprinting(bool toggle)
    {
        IsSprinting = toggle;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * MovementAttributes.GroundCheckStartHeight, MovementAttributes.GroundCheckRadius);
        Gizmos.DrawWireSphere(transform.position + transform.up * MovementAttributes.GroundCheckEndHeight, MovementAttributes.GroundCheckRadius);
    }
}
