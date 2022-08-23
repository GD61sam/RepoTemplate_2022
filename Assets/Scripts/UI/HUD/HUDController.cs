using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private TextMeshProUGUI _interactionText;

    [SerializeField] private TextMeshProUGUI _inventoryFullText;
    [SerializeField] private float _inventoryFullTimer = 2;

    //UNITY METHODS---------------------------------------
    private void Start()
    {
        InteractionManager.Current.OnUpdateUI.AddListener(SetInteractionText);

        InventorySystem.Current.InventoryFullUITrigger.AddListener(TriggerInventoryFullText);
    }

    private void OnDisable()
    {
        InteractionManager.Current.OnUpdateUI.RemoveListener(SetInteractionText);

        InventorySystem.Current.InventoryFullUITrigger.RemoveListener(TriggerInventoryFullText);
    }

    //CUSTOM METHODS -------------------------------------
    public void SetInteractionText(bool enabled)
    {
        _interactionText.enabled = enabled;

        if (InteractionManager.Current.CurrentInteractableData == null)
        {
            
            return;
        }

        InteractableObjectData Data = InteractionManager.Current.CurrentInteractableData;

        switch(Data.InteractableType)
        {
            case(EnumInteractionTypes.Basic):

                _interactionText.text = "Press 'E' to interact with " + Data.Name;
                break;

            case (EnumInteractionTypes.Collectable):

                _interactionText.text = "Press 'E' to collect " + Data.Name;
                break;

            case (EnumInteractionTypes.Trigger):

                _interactionText.text = "Press 'E' to interact with " + Data.Name;
                break;

        }
    }

    public void TriggerInventoryFullText()
    {
        StopCoroutine(InventoryFullText());

        _inventoryFullText.enabled = true;

        StartCoroutine(InventoryFullText());
    }

    IEnumerator InventoryFullText()
    {
       yield return new WaitForSeconds(_inventoryFullTimer);

        _inventoryFullText.enabled = false;

        StopCoroutine(InventoryFullText());
    }

}
