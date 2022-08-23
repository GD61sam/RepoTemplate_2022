using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Scriptable Object / Inventory Item Data / Generic")]
public class InventoryItemData : ScriptableObject
{
    [Title("Item Data")]
    public string Name = "Name";
    [PreviewField(128, ObjectFieldAlignment.Left)] public Sprite Icon;
    public EnumInventoryItemTypes ItemType = EnumInventoryItemTypes.General;
    [TextArea]public string Description = "Description";
    
    [Title("Aditional Data")]
    public GameObject Prefab;    
    public int MaxStackSize = 10;
    public float Weight = 1.0f;
    public float Value = 10;
}
