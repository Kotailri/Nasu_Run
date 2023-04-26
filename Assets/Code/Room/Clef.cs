using System.Collections;
using UnityEngine;

public class Clef : MonoBehaviour
{
    public bool isMagnetic;
    public bool instaMagnet;
    public float magnetRadius;

    private GameObject player;
    private bool moveTowardsPlayer = false;
    private float speedToPlayer = 8.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetInstaMagnetic()
    {
        isMagnetic = true;
        instaMagnet = true;

        if (isMagnetic && instaMagnet)
            StartCoroutine(MagneticTimer());
    }

    public void SetMagnetic(float magnetRadius_)
    {
        isMagnetic = true;
    }

    private IEnumerator MagneticTimer()
    {
        yield return new WaitForSeconds(1f);
        moveTowardsPlayer = true;
    }

    private void Update()
    {
        if (isMagnetic && !moveTowardsPlayer && !instaMagnet)
        {
            if (Utility.IsWithinRadius(player.transform.position, transform.position, magnetRadius))
            {
                moveTowardsPlayer = true;
            }
        }

        if (moveTowardsPlayer)
        {
            speedToPlayer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, ((Global.RoomSpeed/5) + speedToPlayer) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.audioManager.PlaySound("ding");
            Managers.scoreManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
