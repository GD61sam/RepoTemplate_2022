//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveManager : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    public TMP_InputField SaveName;
    public string[] SaveFiles;
      
    //CUSTOM METHODS -------------------------------------
    public void OnSave()
    {
        SerializationManager.Save(SaveName.text, SaveData.Current);
    }

    //gets the files within the saves folder
    public void GetLoadFiles()
    {
        //Check if "saves" folder exists
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            //if not create a "saves" folder
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        SaveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
    }


}
