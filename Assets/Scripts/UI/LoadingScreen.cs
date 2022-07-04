//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private Image _loadingfBarFill;     

    //CUSTOM METHODS -------------------------------------
    public void UpdateBar(float value)
    {
        _loadingfBarFill.fillAmount = value;
    }
}
