using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    private bool hasShield = false;

    private void Start()
    {
        shield.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void HandleShieldDamage(GameObject obj)
    {
        if (obj.TryGetComponent(out TagManager tm))
        {
            if (tm.IsOfTag(Tags.DisabledByShield))
            {
                tm.GetComponent<BoxCollider2D>().enabled = false;
            }

            if (tm.IsOfTag(Tags.KilledByShield))
            {
                Destroy(obj);
            }
        }
    }

    public bool HasShield()
    {
        return hasShield;
    }

    public void GiveShield()
    {
        hasShield = true;
        shield.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void RemoveShield()
    {
        hasShield = false;
        shield.GetComponent<SpriteRenderer>().enabled = false;
    }
}
