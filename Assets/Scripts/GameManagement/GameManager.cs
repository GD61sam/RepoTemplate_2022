//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private GameObject _loadingScreen;

    //PRIVATE VALUES--------------------------------------
    private List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
    private float _totalSceneProgress;

    //PUBLC VALUES----------------------------------------
    public static GameManager Current;

    //UNITY METHODS---------------------------------------
    private void Awake()
    {
        if(Current != null || Current != this)
        {
            Destroy(Current);
        }

        Current = this;

        SceneManager.LoadSceneAsync((int)EnumSceneIndexes.MainMenu, LoadSceneMode.Additive);
    }

    //CUSTOM METHODS -------------------------------------
    public void LoadGame()
    {
        _loadingScreen.SetActive(true);
        _scenesLoading.Add(SceneManager.UnloadSceneAsync((int)EnumSceneIndexes.MainMenu));
        _scenesLoading.Add(SceneManager.LoadSceneAsync((int)EnumSceneIndexes.Gameplay, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    public void LoadMenu()
    {
        _loadingScreen.SetActive(true);
        _scenesLoading.Add(SceneManager.LoadSceneAsync((int)EnumSceneIndexes.MainMenu, LoadSceneMode.Additive));
        _scenesLoading.Add(SceneManager.UnloadSceneAsync((int)EnumSceneIndexes.Gameplay));

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < _scenesLoading.Count; i++)
        {
            while(!_scenesLoading[i].isDone)
            {
                _totalSceneProgress = 0;

                foreach (AsyncOperation operation in _scenesLoading)
                {
                    _totalSceneProgress += operation.progress;
                }

                _totalSceneProgress = (_totalSceneProgress / _scenesLoading.Count * 100f);

                _loadingScreen.GetComponent<LoadingScreen>().UpdateBar(Mathf.RoundToInt(_totalSceneProgress));

                yield return null;
            }

            _loadingScreen.gameObject.SetActive(false);
            _scenesLoading.Clear();
        }
    }
}
