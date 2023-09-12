using UnityEngine;

public class Witch : ActorBase
{
	private Transform playerTransform;
	public float teleportDistance = 10f;

	private void Awake()
	{
		playerTransform = transform;
		move();

	}

	protected override void move()
	{
		Vector2 direction = playerTransform.position - transform.position;
		direction.Normalize();
		transform.position += (Vector3)direction * speed * Time.deltaTime;

		if (Vector2.Distance(transform.position, playerTransform.position) < teleportDistance)
		{
			TeleportToRandomLocation();
		}
	}

	private void TeleportToRandomLocation()
	{
		float randomX = Random.Range(playerTransform.position.x - teleportDistance, playerTransform.position.x + teleportDistance);
		float randomY = Random.Range(playerTransform.position.y - teleportDistance, playerTransform.position.y + teleportDistance);

		Vector2 randomPosition = new Vector2(randomX, randomY);
		transform.position = randomPosition;
	}

	protected override void Attack()
	{

	}
}
