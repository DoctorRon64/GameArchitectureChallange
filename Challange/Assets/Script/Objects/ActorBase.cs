using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBase : MonoBehaviour, IDamagable
{
	public float Health { get; set; }
	protected float speed;
	protected abstract void move();
    protected abstract void Attack();

	public void TakeDamage(float _damage)
	{
		Health -= _damage;
		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{

	}
}
