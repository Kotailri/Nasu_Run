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

    private Rigidbody2D rb;
    private Vector2 playerSize;
    private Alarm dashAlarm;
    private bool isDashing = false;

    private Vector3 dashDirection;
    public GameObject afterImage;

    [HideInInspector]
    public Vector2 directionFacing;
    public GameObject movementIndicator;
    private RollComboBonus rollCombo;
    private void Start()
    {
        rollCombo = GetComponent<RollComboBonus>();
        dashAlarm = new Alarm(Config.dashCooldown);
        rb = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<BoxCollider2D>().size;
    }

    private void HandleMovement()
    {
        Vector3 velocity = Vector3.zero;
        Vector2 controllerInput = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));

        if (controllerInput != Vector2.zero)
        {
            velocity = controllerInput;
        }
        else
        {
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
        }

        if (velocity != Vector3.zero)
            directionFacing = velocity.normalized;
        else
            directionFacing = new Vector3(1,0,0);


        if (isDashing)
        {
            if (dashDirection == Vector3.zero)
            {
                rb.velocity = new Vector3(1, 0, 0) * Config.playerMovespeed * Config.dashPower;
            }
            else
            {
                rb.velocity = dashDirection.normalized * Config.playerMovespeed * Config.dashPower;
            }
                
        }
        else
        {
            rb.velocity = velocity.normalized * Config.playerMovespeed;
            dashDirection = velocity;
            movementIndicator.transform.rotation = Quaternion.Euler(0,0, Mathf.Atan2(directionFacing.y, directionFacing.x) * Mathf.Rad2Deg);
        }
        
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    private void HandleDash()
    {
        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.LeftShift)) && dashAlarm.IsAvailable())
        {
            rollCombo.StartRollCombo();
            Managers.audioManager.PlaySound("shuffle");
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
        int afterImageCount = 3;
        for(int i = 0; i < afterImageCount; i++)
        {
            yield return new WaitForSecondsRealtime((float)Config.dashTimer / (float)afterImageCount);
            Instantiate(afterImage, transform.position, Quaternion.identity);
        }
        rollCombo.EndRollCombo();
        isDashing = false;
    }

    private void ClampPosition()
    {
        Vector2 minBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 playerPos = transform.position;

        float minX = minBound.x + (playerSize.x / 2) - 0.1f;
        float maxX = maxBound.x - (playerSize.x);
        float minY = minBound.y + (playerSize.y / 2) + 0.1f;
        float maxY = maxBound.y - (playerSize.y / 2) - 1.2f;

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
