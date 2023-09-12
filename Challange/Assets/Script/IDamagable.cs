using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public float Health { get; set; }
    public void TakeDamage(float _damage);
}
