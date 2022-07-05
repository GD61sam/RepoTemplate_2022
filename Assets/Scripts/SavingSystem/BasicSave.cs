//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSave : MonoBehaviour
{
    //CUSTOM METHODS -------------------------------------
    public void OnSave()
    {
        SerializationManager.Save(SerializationManager.CurrentSaveName, SaveData.Current);
    }
}
