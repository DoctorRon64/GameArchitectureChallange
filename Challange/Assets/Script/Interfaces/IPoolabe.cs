using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolabe
{
	bool Active { get; set; }
	public void DisablePoolabe();
	public void EnablePoolabe();

	public void SetPosition(Vector2 _pos);
}
