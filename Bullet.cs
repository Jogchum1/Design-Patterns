using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet
{
    public int Damage { get; set; }
    public BulletType BulletTypes { get; set; } = BulletType.Normal;
    
    public Bullet(int _damage)
    {
        Damage = _damage;
    }

    public void Hit()
    {
        Debug.Log("Do Damage");
    }
}
