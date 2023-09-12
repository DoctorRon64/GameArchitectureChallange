using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorBase
{
	Rigidbody2D rb2d;
	[SerializeField] private float linearDrag = 2.0f;
	[SerializeField] private float angularDrag = 2.0f;
	List<ICommand> commands = new List<ICommand>();

	private void Awake()
	{
		commands.Add(new FireGunCommand());
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
		InputHandler inputHandler = new InputHandler(commands);
		ICommand command = inputHandler.HandleInpute();
		command.Execute(gameObject);
	}

	protected override void move()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontalInput, verticalInput);
		rb2d.AddForce(movement * speed);
	}
}

public class FireGunCommand : MonoBehaviour, ICommand
{
	ObjectPool<Bullet> BulletPool;
	
	void Awake()
	{
		BulletPool = new ObjectPool<Bullet>();
	}
	public void Execute(GameObject actor)
	{
		FireGun();
	}

	private void FireGun()
	{
		Bullet bullet = BulletPool.RequestObject();
	}

	public void OnBulletFired(Bullet bullet)
	{
		BulletPool.ReturnObjectToPool(bullet);
	}
}
