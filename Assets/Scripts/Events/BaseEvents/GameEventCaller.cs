using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventCaller<T> : MonoBehaviour
{
    //SERIALIZED VARIABLES-----------------------------------------------
    [SerializeField] private T _value;
    [SerializeField] private GameEvent<T> _gameEvent;

    //UNITY FUNCTIONS----------------------------------------------------
    private void Start()
    {
        //Call Invoke function on GameEvent asset
        //Kickstarts the entire system
        _gameEvent.Invoke(_value);
    }
}
