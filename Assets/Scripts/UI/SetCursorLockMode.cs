using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorLockMode : MonoBehaviour
{
    private void SetCursorVisable(bool isVisable)
    {
        Cursor.visible = isVisable;
    }

    public void SetModeNone()
    {
        Cursor.lockState = CursorLockMode.None;
        SetCursorVisable(true);
    }

    public void SetModeConfined()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SetCursorVisable(true);
    }

    public void SetModeLocked()
    {
        Cursor.lockState = CursorLockMode.Locked;

        SetCursorVisable(false);
    }
}
