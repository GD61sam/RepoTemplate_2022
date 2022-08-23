//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private Tab _defaultTab;
    [SerializeField] private PannelGroup _pageController;

    //PRIVATE VALUES--------------------------------------
    private List<Tab> _tabs;

    private Tab _selectedTab;

    //UNITY METHODS---------------------------------------
    private void Start()
    {
        OnTabSelected(_defaultTab);
    }


    //CUSTOM METHODS -------------------------------------
    public void Subscribe(Tab button)
    {
        if(_tabs == null)
        {
            _tabs = new List<Tab>();
        }

        _tabs.Add(button);
    }

    public void OnTabEnter(Tab button)
    {
        ResetTabs();

        if(_selectedTab == null || button != _selectedTab)
        {
            button.SetHighlighted();
        }
    }

    public void OnTabExit(Tab button)
    {
        ResetTabs();
    }

    public void OnTabSelected(Tab button)
    {
        if(_selectedTab != null)
        {
            _selectedTab.Deselected();
        }

        _selectedTab = button;

        _selectedTab.Selected();

        ResetTabs();

        button.SetSelected();

        int index = button.transform.GetSiblingIndex();
        
        if(_pageController != null)
        {
            _pageController.SetPageIndex(index);
        }
    }

    public void ResetTabs()
    {
        if (_tabs == null) return;


        foreach (Tab button in _tabs)
        {
            if(_selectedTab != null && button == _selectedTab) { continue; }
            button.SetIdle();
        }
    }


}
