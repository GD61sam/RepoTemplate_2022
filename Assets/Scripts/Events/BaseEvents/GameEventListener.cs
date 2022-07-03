using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListener<T> : MonoBehaviour
{
    //SERIALIZED VARIABLES-----------------------------------------------
    [Header("Game Event")]
    [SerializeField] private GameEvent<T> _gameEvent;

    //PUBLIC EVENTS------------------------------------------------------
    public UnityEvent<T> OnInvoke;

    //UNITY FUNCTIONS----------------------------------------------------
    //add listener on enable or start
    private void OnEnable()
    {
        _gameEvent.Event.AddListener(GameEventInvoked);
    }

    //remove listener on disable or destroy
    private void OnDisable()
    {
        _gameEvent.Event.RemoveListener(GameEventInvoked);
    }

    //CUSTOM FUNCTIONS---------------------------------------------------
    //this executes when GameEvent itself is invoked
    private void GameEventInvoked(T parm)
    {
        OnInvoke.Invoke(parm);
    }
}
