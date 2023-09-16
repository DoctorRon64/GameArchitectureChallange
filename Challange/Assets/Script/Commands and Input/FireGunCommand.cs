using UnityEngine;

public class FireGunCommand : MonoBehaviour, ICommand
{
	//ObjectPool<Bullet> BulletPool;
	//BulletPool = new ObjectPool<Bullet>();

	public void Execute()
	{
		Debug.Log("fire");

		//FireGun();
	}

	/*private void FireGun()
	{
		Bullet bullet = BulletPool.RequestObject();
	}

	public void OnBulletFired(Bullet bullet)
	{
		BulletPool.ReturnObjectToPool(bullet);
	}*/
}
