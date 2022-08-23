//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelGroup : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private List<GameObject> _pages = new List<GameObject>();

    //PUBLC VALUES----------------------------------------
    public int PageIndex { get; private set; }

    //CUSTOM METHODS -------------------------------------
    public void ShowCurrentPannel()
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            if(i == PageIndex)
            {
                _pages[i].gameObject.SetActive(true);
            }
            else
            {
                _pages[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetPageIndex(int index)
    {
        PageIndex = index;
        ShowCurrentPannel();
    }

}
