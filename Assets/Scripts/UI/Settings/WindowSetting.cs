//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Scriptable Object / Setting Configuration / Window"))]
public class WindowSetting : IntSettings
{
    //SERIALIZED VAULES-----------------------------------


    //CUSTOM METHODS -------------------------------------
    public override void SetValue(int newValue)
    {
        base.SetValue(newValue);

        if(newValue == 0)
        {
            //fullscreen
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.ExclusiveFullScreen);
        }

        if(newValue == 1)
        {
            //borderless
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow);
        }

        if(newValue == 2)
        {
            //windowed
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
        }
        
    }

}
