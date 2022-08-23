//PROPERTY OF SAM MCKINNEY - 2022
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommandBase
{
    //PRIVATE VALUES--------------------------------------
    private string _commandID;
    private string _commandDescription;
    private string _commandFormat;

    //PUBLC VALUES----------------------------------------
    public string CommandID { get { return _commandID; } }
    public string CommandDescription { get { return _commandDescription; } }
    public string CommandFormat { get { return _commandFormat; } }

    //CONSTRUCTOR METHODS---------------------------------
    public DebugCommandBase(string id, string description, string format)
    {
        _commandID = id;
        _commandDescription = description;
        _commandFormat = format;
    }
}

public class DebugCommand : DebugCommandBase
{
    //PRIVATE VALUES--------------------------------------
    private Action _command;

    //CONSTRUCTOR METHODS---------------------------------
    public DebugCommand(string id, string description, string format, Action command) : base (id, description, format)
    {
        _command = command;
    }

    //CUSTOM METHODS -------------------------------------
    public void Invoke()
    {
        _command.Invoke();
    }
}
