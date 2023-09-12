using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private List<ICommand> allKeyCommands = new List<ICommand>();
    [SerializeField] private List<KeyCode> keys = new List<KeyCode>();

    public InputHandler(List<ICommand> _commands)
    {
        for (int i = 0; i < _commands.Count; i++)
        {
            this.allKeyCommands[i] = _commands[i];
        }
    }

    public ICommand HandleInpute()
    {
        for (int i =0; i < allKeyCommands.Count;)
        {
			if (Input.GetKeyDown(keys[i]))
			{
				return allKeyCommands[i];
			}
		}
        return null;
    }
}
