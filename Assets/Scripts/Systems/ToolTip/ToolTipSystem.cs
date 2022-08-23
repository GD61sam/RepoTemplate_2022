//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    //PRIVATE VALUES--------------------------------------
    //PUBLC VALUES----------------------------------------
    public ToolTip tooltip;
    public static ToolTipSystem Current { get; private set; }
    //PROPERTIES------------------------------------------

    //UNITY METHODS---------------------------------------
    private void Awake()
    {
        if (Current != null && Current != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Current = this;
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    //CUSTOM METHODS -------------------------------------
    public void Show(string header, string content)
    {
        Current.tooltip.SetText(header, content);
        Current.tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        Current.tooltip.gameObject.SetActive(false);
    }
}
