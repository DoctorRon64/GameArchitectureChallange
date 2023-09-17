using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolabe
{
	public bool Active {  get; set; }


    public void OnEnableObject()
	{
		gameObject.SetActive(true);
        Debug.Log("bULLET ENABLE");
	}

	public void OnDisableObject()
	{
        gameObject.SetActive(false);
        Debug.Log("Bullet fired");
	}
}
