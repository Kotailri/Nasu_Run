using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TagManager tm))
        {
            if (tm.IsOfTag(Tags.DamagedByBullets))
            {
                if (collision.gameObject.TryGetComponent(out Enemy e))
                    e.TakeDamage(1);
                else
                    Utility.PrintWarn(gameObject.name + " has damaged by bullets tag but is not an enemy");
                Destroy(gameObject);
            }
        }
    }
}
