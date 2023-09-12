using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : State
{

	public void Setup()
	{

	}

	public override void OnEnter()
	{

	}

	public override void OnUpdate()
	{
		if (Vector2.Distance(transform.position, targetPosition) < approchDistance)
		{

		}
	}

	public override void OnExit()
	{
		//owner.switchState(idle)
	}


}
