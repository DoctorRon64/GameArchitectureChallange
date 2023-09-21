using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private float speed = 15f;
    private Rigidbody2D rb;

    public bool Active { get; set; }

    public delegate void BulletCollision(Bullet _bullet);
	public event BulletCollision OnBulletCollision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IDamagable>() != null)
        {
            //Invoking Event
			OnBulletCollision?.Invoke(this);
        }
    }

	public void DisablePoolabe()
	{
        gameObject.SetActive(false);
	}

	public void EnablePoolabe()
	{
        gameObject.SetActive(true);
	}

    public void SetPosition(Vector2 _pos)
    {
        transform.position = _pos;
    }
}