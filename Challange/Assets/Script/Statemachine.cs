using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemachine
{
	private Dictionary<System.Type, State> stateDictionary = new Dictionary<System.Type, State>();
	private State currentState;

    public Statemachine(System.Type startState, params State[] states) {
        foreach (State state in states)
        {
            state.Initiliaze(this);
			stateDictionary.Add(state.GetType(), state);
		}
        switchState(startState);
    }

    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }

    public void switchState(System.Type state)
    {
        currentState?.OnExit();
        currentState = stateDictionary[state];
        currentState?.OnEnter();
    } 
}

public abstract class State
{
	protected Statemachine owner;
	public void Initiliaze(Statemachine _owner)
    {
        this.owner = _owner;
    }

    public virtual void OnEnter() { }
	public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}

