using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
	Rigidbody2D rb2d;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		speed = 10f;
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
