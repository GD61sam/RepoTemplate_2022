using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventorySystem : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private int _maxInventoryItems = 20;

    //PUBLC VALUES----------------------------------------
    public List<InventoryItem> Inventory; // { get; private set; }
    public static InventorySystem Current;

    //PRIVATE VALUES--------------------------------------
    private Dictionary<InventoryItemData, InventoryItem> _itemDictionary;

    //EVENTS----------------------------------------------
    public UnityEvent InventoryFullUITrigger;


    //UNITY METHODS---------------------------------------
    private void Awake()
    {
        if(Current != null && Current != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Current = this;
        }

        Inventory = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }


    //CUSTOM METHODS -------------------------------------
    public InventoryItem GetItem(InventoryItemData itemData)
    {
        if (_itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            return item;
        }

        return null;
    }

    public bool TryAddItem(InventoryItemData itemData)
    {
        if (_itemDictionary.Count > _maxInventoryItems)
        {
            TriggerInventoryFullUI();
            return false;
        }
        else
        {
            AddItem(itemData);
            return true;
        }
    }

    private void AddItem(InventoryItemData itemData)
    {
        //if we already have item add to stack
        //else create new item and add
        if(_itemDictionary.TryGetValue(itemData, out InventoryItem item) && item.StackSize < itemData.MaxStackSize)
        {
            item.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            Inventory.Add(newItem);
            _itemDictionary.Add(itemData, newItem);
        }
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        //remove item from inventory - reduce stack size
        //if stack size is 0 remove from lists
        if (_itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();

            if(item.StackSize == 0)
            {
                Inventory.Remove(item);
                _itemDictionary.Remove(itemData);
            }
        }
    }

    public void TriggerInventoryFullUI()
    {
        InventoryFullUITrigger?.Invoke();
    }
}
