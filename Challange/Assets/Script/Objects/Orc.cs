using UnityEngine;

public class Orc : ActorBase
{
	[SerializeField] private Statemachine moveBehaviour;

	private void Awake()
	{

	}

	private void FixedUpdate()
	{
		moveBehaviour.OnUpdate();
	}

	protected override void move()
	{
		
	}

	protected override void Attack()
	{

	}
}
