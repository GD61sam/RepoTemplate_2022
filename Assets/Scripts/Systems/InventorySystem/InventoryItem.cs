using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    //Items that can be added to inventory
    //keeps track of stack size
    public InventoryItemData Data { get; private set; }
    public int StackSize { get; private set; }

    public InventoryItem(InventoryItemData sourceData)
    {
        Data = sourceData;
        AddToStack();
    }

    public void AddToStack()
    {
        StackSize++;
    }

    public void RemoveFromStack()
    {
        StackSize--;
    }

    public void CreateNewStack()
    {

    }
}
