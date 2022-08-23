//PROPERTY OF SAM MCKINNEY - 2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    //SERIALIZED VAULES-----------------------------------
    [SerializeField] private string _input;

    //PRIVATE VALUES--------------------------------------
    private bool _showConsole;
    private bool _showHelp = false;
    private List<object> commandList;
    private Vector2 scroll;

    //PUBLC VALUES----------------------------------------
    public static DebugCommand Kill_All;
    public static DebugCommand Show_Help;

    //PROPERTIES------------------------------------------


    //UNITY METHODS---------------------------------------
    void Awake()
    {
        Kill_All = new DebugCommand("kill_all", "removes all enemies from scene", "kill_all", () =>
        {
            //action here
            Debug.Log("Kill All");
        });

        Show_Help = new DebugCommand("show_help", "Shows a list of all commands", "help", () =>
        {
            _showHelp = true;
            Debug.Log("Help");
        });

        commandList = new List<object>
        {
            Kill_All,
            Show_Help
        };
    }

    private void OnGUI()
    {
        if (!_showConsole) return;

        float y = 0f;

        if (_showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.CommandFormat} - {command.CommandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100f;
        }       

        GUI.Box(new Rect(0, y, Screen.width, 30), "");

        GUI.backgroundColor = new Color(0, 0, 0, 0);

        _input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), _input);

    }

    //CUSTOM METHODS -------------------------------------
    public void OnDebugMenu()
    {
        _showConsole = !_showConsole;
        Debug.Log("Debug");
    }

    public void OnReturn()
    {
        if (!_showConsole) return;

        Debug.Log("return");

        HandleInput();
        _input = "";
    }

    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if(_input.Contains(commandBase.CommandFormat))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }

            if(!_input.Contains(Show_Help.CommandFormat))
            {
                _showHelp = false;
            }
        }
    }
}
