//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    //SERIALIZED VAULES-----------------------------------
    //PRIVATE VALUES--------------------------------------
    private static SaveData _current;

    //PUBLC VALUES----------------------------------------
    public static SaveData Current
    {
        get
        {
            if(_current == null)
            {
                _current = new SaveData();
            }

            return _current;
        }
    }

    //create resouces here
    public CharacterProfile PlayerProfile = new CharacterProfile();

    //PROPERTIES------------------------------------------       
    //UNITY METHODS---------------------------------------
   //CUSTOM METHODS -------------------------------------

}
