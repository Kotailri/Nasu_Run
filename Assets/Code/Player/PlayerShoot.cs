using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    private KeyCode keycodeShoot = KeyCode.Space;
    private Alarm shootTimer;

    private void Start()
    {
        shootTimer = new Alarm(Config.shootCooldown);
    }

    void Update()
    {
        if ((Input.GetKeyDown(keycodeShoot) || Input.GetMouseButtonDown(0)) && shootTimer.IsAvailable())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Managers.audioManager.PlaySound("fluff");
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        shootTimer.ResetTimer();
    }
}
