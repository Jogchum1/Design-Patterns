using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDecorator //: BulletDecorator
{
    
    public override IBullet Decorate(IBullet bullet)
    {
        Debug.Log("Added Explosions");
        bullet.BulletTypes |= BulletType.Explosive;
        return bullet;
    }
    
}
