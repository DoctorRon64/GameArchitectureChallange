using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
	Rigidbody2D rb2d;
	[SerializeField] private float linearDrag = 2.0f;
	[SerializeField] private float angularDrag = 2.0f;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.drag = linearDrag;
		rb2d.angularDrag = angularDrag;
		speed = 10f;
	}

	private void FixedUpdate()
	{
		move();
	}

	protected override void Attack()
	{
		
	}

	protected override void move()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontalInput, verticalInput);
		rb2d.AddForce(movement * speed);
	}
}
