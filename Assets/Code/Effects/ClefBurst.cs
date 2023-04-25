using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClefBurst : MonoBehaviour
{
    public GameObject clef;
    public int numClefs = 10;

    [Space(10.0f)]
    public float spawnRadius = 5.0f;
    public float coinMoveTime = 1.0f;

    public void Create()
    {
        for (int i = 0; i < numClefs; i++)
        {
            float angle = i * Mathf.PI * 2 / numClefs;
            Vector2 spawnPos = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
            GameObject coin = Instantiate(clef, transform.position, Quaternion.identity);
            coin.GetComponent<Clef>().SetInstaMagnetic();
            coin.transform.position = transform.position;

            BoxCollider2D coinCollider = coin.GetComponent<BoxCollider2D>();
            Vector2 direction = spawnPos - (Vector2)transform.position;
            LeanTween.move(coin, (Vector2)transform.position + direction, coinMoveTime).setOnStart(() => coinCollider.enabled = false)
                     .setOnComplete(() => coinCollider.enabled = true);
        }
        Destroy(gameObject);
    }
}
