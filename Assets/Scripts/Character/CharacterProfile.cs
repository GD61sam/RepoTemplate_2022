//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Scriptable Object / Profile / Character"))]
[System.Serializable]
public class CharacterProfile : ScriptableObject
{
    //SERIALIZED VAULES-----------------------------------
    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    public string Name;
    public Sprite Icon;

    public float Level;

    
    public float MaxHealth;
    public float MaxManna;
    public float MaxStamina;

    //PROPERTIES------------------------------------------
       
    //CUSTOM METHODS -------------------------------------

}
