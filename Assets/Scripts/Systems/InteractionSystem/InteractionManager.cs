using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    public InteractionManager Current;

    public GameObject CurrentInteractable;
    public bool PlayerCanInteract;

    private void Awake()
    {
        if(Current != null || Current != this)
        {
            Destroy(this);
        }

        Current = this;
    }

    //check if interaction is allowed
    public void TryAcknowledgeInteraction(GameObject interactable)
    {
        //check if player is able to interact with an object
        if (PlayerCanInteract == false) return;

        //check if manager is already interacting with an object
        if (CurrentInteractable != null) return;

        AcknowledgeInteraction(interactable);
    }

    //if player is able to interact and is not already interacting with object
    //then allow interaction
    private void AcknowledgeInteraction(GameObject interactable)
    {
        CurrentInteractable = interactable;

        UpdateUI();
    }

    public void UpdateUI()
    {

    }

    public void StopAcknowledgingInteraction()
    {
        CurrentInteractable = null;

        UpdateUI();
    }
}
