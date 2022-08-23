//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InteractableBase : MonoBehaviour, IInteractable
{
    //PUBLC VALUES----------------------------------------
    public InteractableObjectData InteractableData;

    //PRIVATE VALUES--------------------------------------
    public GameObject _target { get; private set; }
    [ShowInInspector][ReadOnly] private float _distance;

    //UNITY METHODS---------------------------------------
    protected virtual void Start()
    {
        _target = GameObject.FindGameObjectWithTag(InteractableData.TargetTag);
        InteractableData.SetInteractable(gameObject);
    }

    protected virtual void Update()
    {
        if(_target == null)
        {
            Debug.LogWarning($"Target of {gameObject.name} is null", gameObject);
            return;
        }
        if (InteractionManager.Current == null)
        {
            Debug.LogWarning("Interaction Manager is null");
            return;
        }

        //get distance of target
        _distance = Vector3.Distance((transform.position + InteractableData.InteractionSourceOffset), _target.transform.position);

        if(_distance < InteractableData.InteractionDistance)
        {
            //Check if we can allow possible interaction
            InteractionManager.Current.TryAwknowledgePossibleInteraction(InteractableData);
        }
        else
        {
            if (InteractionManager.Current.CurrentInteractableData != InteractableData) return;

            InteractionManager.Current.StopAcknowledgingInteraction();
        }
    }

    protected void OnDisable()
    {
        InteractionManager.Current.StopAcknowledgingInteraction();
    }

    //CUSTOM METHODS -------------------------------------
    public virtual void Interact()
    {
        if (!InteractionManager.Current.TryInteract(InteractableData)) return;

        //Preform interaction
        Debug.Log($"interact with {InteractableData.Name}");

    }

    protected virtual void OnDrawGizmosSelected()
    {
        if (InteractableData == null) return;

        Gizmos.DrawWireSphere((transform.position + InteractableData.InteractionSourceOffset), InteractableData.InteractionDistance);
        Gizmos.DrawSphere((transform.position + InteractableData.InteractionSourceOffset), 0.5f);
    }

}
