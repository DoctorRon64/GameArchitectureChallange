using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolabe
{
    private float speed = 15f;
    private Rigidbody2D rb;

    public bool Active { get; set; }
    public event Action<GameObject> BulletCollision;

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
            BulletCollision?.Invoke(gameObject);
        }
    }
}