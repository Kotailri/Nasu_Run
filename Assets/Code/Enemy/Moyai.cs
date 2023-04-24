using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moyai : Enemy
{
    private bool isStunned = false;
    public override void OnDeath()
    {
        if (!isStunned)
        {
            isStunned = true;
            GetComponent<StunEffect>().EnableStunEffect();
            transform.localScale = new Vector3(1, 0.75f, 1);
            GetComponent<SpriteRenderer>().color = new Color(1, 0.8078432f, 1, 1);
            SetHealth(1);
            return;
        }

        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStunned && collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (playerMovement.IsDashing())
            {
                GetComponent<SpawnClefBurst>().ClefBurst();
                Destroy(gameObject.transform.parent.gameObject, 0.25f);
            }
        }
    }
}
