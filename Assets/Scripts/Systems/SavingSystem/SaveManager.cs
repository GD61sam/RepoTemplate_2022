//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private GameObject _fileButtonPrefab;
    [SerializeField] private GameObject _loadArea;

    //PRIVATE VALUES--------------------------------------
    private List<GameObject> _filePrefabs = new List<GameObject>();
    private int index = -1;

    //PUBLC VALUES----------------------------------------
    public TMP_InputField SaveName;
    public string[] SaveFiles;

    //CUSTOM METHODS -------------------------------------
    public void CreateNewSave()
    {
        if (SaveName.text == "")
        {
            return;
        }

        SerializationManager.SetSaveName(SaveName.text);
        OnSave();        
        GameManager.Current.LoadGame();
    }

    public void OnSave()
    {
        SerializationManager.Save(SerializationManager.CurrentSaveName, SaveData.Current);
    }

    public void DisplayLoadFiles()
    {
        GetLoadFiles();
        ClearDisplayedLoadFiles();

        for (int i = 0; i < SaveFiles.Length; i++)
        {
            GameObject loadFilePrefab = Instantiate(_fileButtonPrefab);
            loadFilePrefab.transform.SetParent(_loadArea.transform, false);

            loadFilePrefab.GetComponentInChildren<TextMeshProUGUI>().text = SaveFiles[i].Replace(Application.persistentDataPath + "/saves/", "");

            loadFilePrefab.GetComponent<Button>().onClick.AddListener(() =>
            {
                index = i;

                DisplaySaveFileOptions();
                
            });
        }
    }

    //gets the files within the saves folder
    private void GetLoadFiles()
    {
        //Check if "saves" folder exists
        if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
        {
            //if not create a "saves" folder
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        SaveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
    }

    //clears the loaded files 
    private void ClearDisplayedLoadFiles()
    {
        for (int i = _filePrefabs.Count; i > 0; i--)
        {
            Destroy(_filePrefabs[i]);
            _filePrefabs.RemoveAt(i);
        }

        _filePrefabs.Clear();
    }

    //displays loaded files to UI
    public void DisplaySaveFileOptions()
    {
        //displays saves option
            //play
            //delete save
    }

    //deletes a save
    public void DeleteSave()
    {        
        //get a path to the saves folder and saves file location
        string path = Application.persistentDataPath + "/saves" + SaveFiles[index].Replace(Application.persistentDataPath + "/saves/", "");

        //deletes specific save file
        File.Delete(path);

        Return();
    }

    //loads a game from loaded files
    public void LoadSavedGame()
    {
        //loads saved game
        SerializationManager.Load(SaveFiles[index]);
        SerializationManager.SetSaveName(SaveFiles[index].Replace(Application.persistentDataPath + "/saves/", ""));

        GameManager.Current.LoadGame();
    }

    public void Return()
    {
        //close option window bring up display window

        DisplayLoadFiles();
    }

}
