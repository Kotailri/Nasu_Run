using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moyai : Enemy
{
    private bool isStunned = false;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void OnDeath()
    {
        if (!isStunned)
        {
            isStunned = true;
            GetComponent<StunEffect>().EnableStunEffect();
            transform.localScale = new Vector3(1, 0.75f, 1);
            GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 1, 1);
            GetComponent<BobbingEffect>().enabled = false;
            SetHealth(1);
            return;
        }

        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isStunned && collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            if (playerMovement.IsDashing())
            {
                Managers.audioManager.PlaySound("success");
                GetComponent<SpawnClefBurst>().ClefBurst();
                collision.gameObject.GetComponent<RollComboBonus>().AddRollKill();
                Die();
            }
        }
    }

    private void Die()
    {
        Managers.audioManager.PlaySound("rocksmash");
        GetComponent<MoyaiDeathAnim>().SetAnimationEnd("moyai_death");
    }

    private void OnDestroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
