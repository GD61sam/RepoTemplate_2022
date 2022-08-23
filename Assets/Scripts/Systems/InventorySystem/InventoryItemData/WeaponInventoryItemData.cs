//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Scriptable Object / Inventory Item Data / Weapon")]
public class WeaponInventoryItemData : EquipmentInventoryItemData
{
    [Title("Weapon Data")]
    [OnValueChanged("CalculateDPS")]public float Damage;
    [OnValueChanged("CalculateDPS")] public float Speed;
    [ShowInInspector] [ReadOnly] private float DPS;

    public void CalculateDPS()
    {
        DPS = Damage * Speed;
    }
}
