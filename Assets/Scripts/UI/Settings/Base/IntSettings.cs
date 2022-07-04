//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntSettings : ScriptableObject
{
    //SERIALIZED VAULES-----------------------------------
    [Header("Setting")]
    [SerializeField] private string _name;
    [SerializeField] private int _default = 0;


    //CUSTOM METHODS -------------------------------------
    public virtual void SetValue(int newValue)
    {
        PlayerPrefs.SetFloat(_name, newValue);
    }

    public int GetValue()
    {
        return PlayerPrefs.GetInt(_name, _default);
    }

    public void Load()
    {
        SetValue(GetValue());
    }
}
