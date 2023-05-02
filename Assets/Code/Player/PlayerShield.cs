using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    private Animator anim;
    private bool hasShield = false;

    private void Start()
    {
        shield.GetComponent<SpriteRenderer>().enabled = false;
        anim = shield.GetComponent<Animator>();
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
        anim.SetBool("broken", false);
        anim.SetTrigger("animSwap");

    }

    public void RemoveShield()
    {
        hasShield = false;
        anim.SetBool("broken", true);
        anim.SetTrigger("animSwap");
        Utility.InvokeLambda(() => { shield.GetComponent<SpriteRenderer>().enabled = false; }, 1.5f);
    }
}
