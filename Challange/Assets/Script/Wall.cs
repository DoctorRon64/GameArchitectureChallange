using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamagable
{
	public float Health { get; set; }

	public void TakeDamage(float _damage)
	{
		if (_damage > 0) 
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}

}
