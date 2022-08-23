//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    //PUBLC VALUES----------------------------------------
    public static InteractionManager Current;
    public InteractableObjectData CurrentInteractableData;
    public bool PlayerCanInteract = true;

    //EVENTS----------------------------------------------
    public UnityEvent<bool> OnUpdateUI;

    //UNITY METHODS---------------------------------------
    private void Awake()
    {
        if(Current != null && Current != this)
        {
            Destroy(this);
        }

        Current = this;
    }

    //CUSTOM METHODS -------------------------------------
    public void TryAwknowledgePossibleInteraction(InteractableObjectData InteractionData)
    {
        //check if player is able to interact with an object
        if (PlayerCanInteract == false) return;

        //check if current interactable is null
        if(CurrentInteractableData != null)
        {
            //if our new object has a lower weight return
            if (InteractionData.Weight < CurrentInteractableData.Weight) return;
        }

        AwkknowledgePossibleInteraction(InteractionData);
    }

    private void AwkknowledgePossibleInteraction(InteractableObjectData InteractionData)
    {
        CurrentInteractableData = InteractionData;
        UpdateUI(true);
    }

    public void UpdateUI(bool isEnabled)
    {
        OnUpdateUI.Invoke(isEnabled);
    }

    public void StopAcknowledgingInteraction()
    {
        CurrentInteractableData = null;
        UpdateUI(false);
    }

    public bool TryInteract(InteractableObjectData InteractionData)
    {
        //Checks
        if (PlayerCanInteract == false) return false;
        if (CurrentInteractableData != InteractionData) return false;

        return true;
    }
}
