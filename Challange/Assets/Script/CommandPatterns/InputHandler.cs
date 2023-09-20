using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Dictionary<KeyCode, ICommand> allKeyCommands = new Dictionary<KeyCode, ICommand>();

    public void HandleInput()
    {
        foreach (var _keyCommand in allKeyCommands)
        {
            if (Input.GetKey(_keyCommand.Key))
            {
                _keyCommand.Value.Execute();
            }
        }
    }

    public void BindInputToCommand(KeyCode _keycode, ICommand _command)
    {
        if (allKeyCommands.ContainsKey(_keycode))
        {
            allKeyCommands[_keycode] = _command;
        } else
        {
            allKeyCommands.Add(_keycode, _command);
        }
    }

    public void UnBindInput(KeyCode _keycode)
    {
        if (allKeyCommands.ContainsKey(_keycode))
        {
            allKeyCommands.Remove(_keycode);
        }
    }
}

