using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject dashCooldownParticles;

    private KeyCode keycodeLeft = KeyCode.A;
    private KeyCode keycodeRight = KeyCode.D;
    private KeyCode keycodeDown = KeyCode.S;
    private KeyCode keycodeUp = KeyCode.W;
    private KeyCode keycodeDash = KeyCode.LeftShift;

    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Vector2 playerSize;
    private Alarm dashAlarm;
    private bool isDashing = false;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        dashAlarm = new Alarm(Config.dashCooldown);
        rb = GetComponent<Rigidbody2D>();
        playerSize = col.size;
    }

    private void HandleMovement()
    {
        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(keycodeLeft))
        {
            velocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(keycodeRight))
        {
            velocity += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(keycodeUp))
        {
            velocity += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(keycodeDown))
        {
            velocity += new Vector3(0, -1, 0);
        }

        if (isDashing)
        {
            if (velocity == Vector3.zero)
                rb.velocity = new Vector3(1,0,0) * Config.playerMovespeed * Config.dashPower;
            else
                rb.velocity = velocity.normalized * Config.playerMovespeed * Config.dashPower;
        }
        else
        {
            rb.velocity = velocity.normalized * Config.playerMovespeed;
        }
        
    }

    private void HandleDash()
    {
        if ((Input.GetKey(keycodeDash) || Input.GetMouseButton(1)) && dashAlarm.IsAvailable())
        {
            GetComponent<Animator>().SetTrigger("roll");
            dashAlarm.ResetTimer();
            StartCoroutine(DashTimer());
            StartCoroutine(DashCooldown());
        }
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSecondsRealtime(Config.dashCooldown);
        Instantiate(dashCooldownParticles, transform.position + new Vector3(0,0,-1), Quaternion.identity);
    }

    private IEnumerator DashTimer()
    {
        isDashing = true;
        col.enabled = false;
        yield return new WaitForSecondsRealtime(Config.dashTimer);
        isDashing = false;
        col.enabled = true;
    }

    private void ClampPosition()
    {
        Vector2 minBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 playerPos = transform.position;

        float minX = minBound.x + (playerSize.x / 2) - 0.1f;
        float maxX = maxBound.x - (playerSize.x / 2);
        float minY = minBound.y + (playerSize.y / 2) + 0.1f;
        float maxY = maxBound.y - (playerSize.y / 2) - 1;

        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);

        transform.position = playerPos;
    }

    private void Update()
    {
        HandleDash();
        HandleMovement();
        ClampPosition();
    }
}
