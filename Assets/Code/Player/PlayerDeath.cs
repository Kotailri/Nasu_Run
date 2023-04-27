using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    public float explosionForce = 100f;
    public GameOverUI gameOverUI;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void PlayerDie()
    {
        Managers.audioManager.PlaySound("squeak");
        rb.isKinematic = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;

        Global.RoomSpeed = 0;

        Vector2 direction = new(1, 1);
        rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);

        Vector3 rotationDirection = new Vector3(0, 0, Mathf.Sign(direction.x));
        rb.AddTorque(explosionForce, ForceMode2D.Impulse);
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverUI.OpenUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TagManager tm))
        {
            if (tm.IsOfTag(Tags.HitsPlayer) && !GetComponent<PlayerMovement>().IsDashing())
            {
                if (TryGetComponent(out PlayerShield shield))
                {
                    if (shield.HasShield())
                    {
                        Managers.audioManager.PlaySound("pop");
                        shield.RemoveShield();
                        shield.HandleShieldDamage(collision.gameObject);
                        return;
                    }
                }
                PlayerDie();
            }
        }
    }
}
