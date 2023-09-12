using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolabe
{
	bool Active { get; set; }
	void OnEnableObject();
	void OnDisableObject();
}
