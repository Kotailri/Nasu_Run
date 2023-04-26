using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.audioManager.PlaySound("inflate");
            collision.gameObject.GetComponent<PlayerShield>().GiveShield();
            Destroy(gameObject);
        }
    }
}
