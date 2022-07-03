using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAction : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _settingsMenu;
    [SerializeField] GameObject _blurVolume;

    public bool IsPaused { get; private set; } = false;

    private TimeControl _time;
    private SetCursorLockMode _cursor;

    private void Start()
    {
        _time = GetComponent<TimeControl>();
        _cursor = GetComponent<SetCursorLockMode>();
    }

    public void SetPause()
    {
        if (IsPaused)
        {
            //unpause
            _time.UnPause();
            _cursor.SetModeLocked();

            SetItems(false);
        }
        else
        {
            //pause
            _time.Pause();
            _cursor.SetModeConfined();
            
            SetItems(true);
        }

    }

    private void SetItems(bool toggle)
    {
        IsPaused = toggle;

        _pauseMenu.SetActive(toggle);
        if(_settingsMenu.activeInHierarchy == true) _settingsMenu.SetActive(toggle);
        _blurVolume.SetActive(toggle);
    }
}
