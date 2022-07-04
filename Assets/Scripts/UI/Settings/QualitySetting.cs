//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Scriptable Object / Setting Configuration / Quality"))]
public class QualitySetting : IntSettings
{
    //CUSTOM METHODS -------------------------------------
    public override void SetValue(int newValue)
    {
        base.SetValue(newValue);

        //set window
        QualitySettings.SetQualityLevel(newValue);
    }

}
