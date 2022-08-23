using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Interactable : InteractableBase
{
    [SerializeField] private InventoryItemData _itemData;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Pick Up");

        if(InventorySystem.Current.TryAddItem(_itemData))
        {
            Destroy(gameObject);
        }
    }
}
