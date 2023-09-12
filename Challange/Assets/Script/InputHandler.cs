using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private List<KeyCommand> allKeyCommands = new List<KeyCommand>();
    private List<ICommand> commandList = new List<ICommand>();

    public InputHandler(List<ICommand> _commandList)
    {
        this.commandList = _commandList;
    }

    public ICommand HandleInput()
    {
        foreach (KeyCommand keyCommand in allKeyCommands)
        {
            if (Input.GetKeyDown(keyCommand.key))
            {
                keyCommand.command.Execute();
            }
        }
        
        return null;
    }

    public void BindInputToCommand(KeyCode _keycode, ICommand _command)
    {
        allKeyCommands.Add(new KeyCommand()
        {
            key = _keycode,
            command = _command
        });
    }

    public void UnBindInput(KeyCode _keycode)
    {
        var items = allKeyCommands.FindAll(x => x.key == _keycode);
        items.ForEach(x => allKeyCommands.Remove(x));
    }
}
