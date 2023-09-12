using UnityEngine;

public class Orc : ActorBase
{
	private Statemachine moveBehaviour;
	private Transform patrolPoint;
	private bool isPatrolling = true;

	private void Awake()
	{
		patrolPoint = new GameObject().transform;
		patrolPoint.position = new Vector3(10f, 0f, 0f);
	}

	private void FixedUpdate()
	{
		move();
	}

	protected override void move()
	{
		
	}

	protected override void Attack()
	{

	}
}
