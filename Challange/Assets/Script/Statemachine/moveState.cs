using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static UnityEngine.UI.Image;

public class moveState : State
{
	[SerializeField] private GameObject Player;

	public void Setup()
	{

	}

	public override void OnEnter()
	{

	}

	public override void OnUpdate()
	{
		/*Vector2 origin = transform.position;
		Vector2 direction = Vector2.up;

		RaycastHit2D hit;

		hit = Physics2D.CircleCast(origin, 10f, direction, 10f);

		if (hit.collider.GetComponent<Player>())
		{
			owner.switchState(Attack);
		}*/
	}

	public override void OnExit()
	{
		//owner.switchState(idle)
	}
}
