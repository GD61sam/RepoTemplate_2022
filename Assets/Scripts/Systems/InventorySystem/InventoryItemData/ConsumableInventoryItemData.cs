//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Scriptable Object / Inventory Item Data / Consumable")]
public class ConsumableInventoryItemData : InventoryItemData
{
    [Title("Consumable Data")]
    public float Food = 10;
    public float Thirst = 10;
    public float Health = 5;
}
