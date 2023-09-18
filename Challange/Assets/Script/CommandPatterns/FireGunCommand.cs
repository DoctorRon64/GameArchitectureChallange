using System.Collections.Generic;
using UnityEngine;

public class FireGunCommand : MonoBehaviour, ICommand
{
	public GameObjectPool ObjectPool;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBulletCount = 5;
    [SerializeField] private int bulletAmount;

    private void Awake()
    {
        ObjectPool = new GameObjectPool(bulletPrefab);

        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject bullet = ObjectPool.RequestObject();
            bullet.GetComponent<Bullet>().BulletCollision += OnBulletCollision;
        }
    }

    public void Execute()
    {
        if (bulletAmount < maxBulletCount)
        {
            FireGun();
        }
    }

    private void FireGun()
    {
        GameObject bullet = ObjectPool.RequestObject();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bulletAmount++;
            FlyBullet(bullet);
        }
    }

    private void OnBulletCollision(GameObject bullet)
    {
        ObjectPool.ReturnObjectToPool(bullet);
        bulletAmount--;
    }

    private void FlyBullet(GameObject _bullet)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 direction = (mousePos - playerPos).normalized;
        _bullet.GetComponent<Bullet>().Fire(direction);
    }
}
