//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    [SerializeField] private List<FloatSetting> _toLoadFloat;

    [SerializeField] private List<IntSettings> _toLoadInt;

    private void Start()
    {
        foreach (FloatSetting setting in _toLoadFloat)
        {
            setting.GetValue();
        }

        foreach (IntSettings setting in _toLoadInt)
        {
            setting.GetValue();
        }
    }
}
