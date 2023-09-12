using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolabe
{
	public bool Active {  get; set; }

	public void OnEnableObject()
	{
		Debug.Log("bULLET ENABLE");
	}

	public void OnDisableObject()
	{
		Debug.Log("Bullet fired");
	}
}
