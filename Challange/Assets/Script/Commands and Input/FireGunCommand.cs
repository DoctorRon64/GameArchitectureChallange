using UnityEngine;

public class FireGunCommand : MonoBehaviour, ICommand
{
	public ObjectPool<Bullet> BulletPool;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        BulletPool = new ObjectPool<Bullet>(bulletPrefab);
    }

    public void Execute()
	{
		Debug.Log("fire");

		FireGun();
	}

	private void FireGun()
	{
		Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
		bullet = BulletPool.RequestObject();
		
		//OnBulletFired(bullet);
    }

	public void OnBulletFired(Bullet bullet)
	{
		BulletPool.ReturnObjectToPool(bullet);
	}
}
