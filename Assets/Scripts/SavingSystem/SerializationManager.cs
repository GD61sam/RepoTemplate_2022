//PROPERTY OF SAM MCKINNEY - 2022
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    //PROPERTIES------------------------------------------   
    //UNITY METHODS---------------------------------------


    //CUSTOM METHODS -------------------------------------
    public static bool Save(string saveName, object saveData)
    {
        //Get or Create a Binary Formatter
        BinaryFormatter formatter = GetBinaryFormatter();

        //Check if "saves" folder exists
        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            //if not create a "saves" folder
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        //get a path to the saves folder and saves file location
        string path = Application.persistentDataPath + "/saves" + saveName + ".save";

        //create the file at pervious made path
        FileStream file = File.Create(path);

        //use formmater to create a binary file at file loaction with savedata
        formatter.Serialize(file, saveData);

        //close file
        file.Close();

        return true;
    }

    public static object Load(string path)
    {
        //check if path exists
        if(!File.Exists(path))
        {
            //early return if path does not exist
            return null;
        }

        //Get or Create a Binary Formatter
        BinaryFormatter formatter = GetBinaryFormatter();

        //Open file at path
        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            //Try to convert binary back to save data
            object save = formatter.Deserialize(file);
            //close file
            file.Close();
            return save;
        }
        catch
        {
            //if unable to convert data
            //throw exception
            Debug.LogErrorFormat("Failed to load file at {0}", path);
            //close file
            file.Close();
            return null;
        }
    }

    private static BinaryFormatter GetBinaryFormatter()
    {
        //create new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        //return formatter
        return formatter;
    }
}
