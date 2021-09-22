using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    int Damage { get; set; }
    BulletType BulletTypes { get; set; }
    void Hit();
}
