//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SavedGames : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private GameObject _savedFilesUIPrefab;
    [SerializeField] private GameObject _loadArea;

    //PRIVATE VALUES--------------------------------------
    private SaveManager _saveManager;
    private List<GameObject> _filePrefabs = new List<GameObject>();
       
    //UNITY METHODS---------------------------------------
    void Start()
    {
        //get loaded files
        _saveManager = GetComponent<SaveManager>();
        _saveManager.GetLoadFiles();

        //display files to UI
        UpdateUI();
    }

    //CUSTOM METHODS -------------------------------------
    public void UpdateUI()
    {
        ClearUI();

        for (int i = 0; i < _saveManager.SaveFiles.Length; i++)
        {
            GameObject loadFilePrefab = Instantiate(_savedFilesUIPrefab);
            loadFilePrefab.transform.SetParent(_loadArea.transform, false);

            loadFilePrefab.GetComponentInChildren<TextMeshProUGUI>().text = _saveManager.SaveFiles[i].Replace(Application.persistentDataPath + "/saves/", "");

            loadFilePrefab.GetComponent<Button>().onClick.AddListener(() =>
            {
                SerializationManager.Load(_saveManager.SaveFiles[i]);
                GameManager.Current.LoadGame();
            });
        }
    }

    public void ClearUI()
    {
        for (int i = _filePrefabs.Count; i > 0; i--)
        {
            Destroy(_filePrefabs[i]);
            _filePrefabs.RemoveAt(i);
        }

        _filePrefabs.Clear();
    }
}
