using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : ActorBase
{
	Rigidbody2D rb2d;
	[SerializeField] private float linearDrag = 2.0f;
	[SerializeField] private float angularDrag = 2.0f;

	private InputHandler inputHandler;
	private List<ICommand> commandsInput = new List<ICommand>();
    [SerializeField] private List<KeyCode> keysInput;

	private void Awake()
	{
		inputHandler = GetComponent<InputHandler>();
		
        ICommand[] foundCommands = GetComponents<ICommand>();
        commandsInput.AddRange(foundCommands);

        for (int i = 0; i < commandsInput.Count; i++)
		{
			inputHandler.BindInputToCommand(keysInput[i], commandsInput[i]);
		}

		rb2d = GetComponent<Rigidbody2D>();
		rb2d.drag = linearDrag;
		rb2d.angularDrag = angularDrag;
		speed = 10f;
	}

	private void FixedUpdate()
	{
		move();
	}

	private void Update()
	{
		Attack();
	}

	protected override void Attack()
	{
		inputHandler.HandleInput();
	}

	protected override void move()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed;
		rb2d.velocity = movement;
	}
}