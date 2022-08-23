//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Scriptable Object / Inventory Item Data / Equipment")]
public class EquipmentInventoryItemData : InventoryItemData
{
    [Title("Equipment Data")]
    public int DurabilityMax = 100;

}
