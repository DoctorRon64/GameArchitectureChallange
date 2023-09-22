using System.Collections.Generic;
using UnityEngine;

public class FireGunCommand : MonoBehaviour, ICommand
{
	public ObjectPool<Bullet> BulletObjectPool;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBulletCount = 5;

    private void Awake()
    {
        BulletObjectPool = new ObjectPool<Bullet>();

		for (int i = 0; i < maxBulletCount; i++)
		{
            GameObject newObject = Instantiate(bulletPrefab);
			Bullet bulletComponent = newObject.GetComponent<Bullet>();
            BulletObjectPool.DeactivateItem(bulletComponent);

            //subscribing to bullet event
		    bulletComponent.OnBulletCollision += deactivateBullet;
        }
	}

    public void Execute()
    {
		FireGun();
	}

	private void FireGun()
    {
        Bullet bullet = BulletObjectPool.RequestObject(new Vector2(transform.position.x + Random.Range(-1f, 3f), transform.position.y + Random.Range(-1f, 3f)));

        if (bullet != null)
        {
            FlyBullet(bullet.gameObject);
        }
    }

    private void deactivateBullet(Bullet _bullet)
    {
        BulletObjectPool.DeactivateItem(_bullet);
        _bullet.OnBulletCollision -= deactivateBullet;
	}

	private void FlyBullet(GameObject _bullet)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 direction = (mousePos - playerPos).normalized;
        _bullet.GetComponent<Bullet>().Fire(direction);
    }
}
