using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEvent<T> : ScriptableObject
{
    //PUBLIC EVENTS-----------------------------------------------------
    //Generic unity event of type T, Defined when we inherit from GameEvent
    public UnityEvent<T> Event;

    //CUSTOM FUNCTIONS---------------------------------------------------
    public void Invoke(T parm)
    {
        Event.Invoke(parm);
    }
}
