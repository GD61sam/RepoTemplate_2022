//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Goal_New
{
    public string Description;
    public bool IsCompleted = false;

    public virtual void CheckStatus()
    {

    }
}
