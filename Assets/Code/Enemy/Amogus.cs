using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amogus : Enemy
{
    private float maxY;
    private float minY;

    private Direction runDirection;

    [Space(10.0f)]
    public GameObject smolAmogus;
    public float spawnDelay;

    private enum Direction
    {
        downLeft,
        upLeft
    }

    public override void TakeDamage(int damage)
    {
        GetComponent<DamageAnim>().PlayDamageAnim();
        base.TakeDamage(damage);
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        Vector3 spriteBounds = bc.bounds.size;
        maxY = Global.boundsRefManager.GetMaxY() + spriteBounds.y / 2;
        minY = Global.boundsRefManager.GetMinY() - spriteBounds.y / 2;

        if (Random.Range(0,2) == 0)
        {
            runDirection = Direction.downLeft;
        }
        else
        {
            runDirection = Direction.upLeft;
        }

        UpdateRunDirection();
        InvokeRepeating(nameof(SpawnAmogus), spawnDelay, spawnDelay);
    }

    private void SpawnAmogus()
    {
        if (Global.RoomSpeed > 0)
            Instantiate(smolAmogus, transform.position + new Vector3(1,0,0), Quaternion.identity);
    }

    private void UpdateRunDirection()
    {
        if (runDirection == Direction.downLeft) 
        {
            runDirection = Direction.upLeft;
        }
        else if (runDirection == Direction.upLeft)
        {
            runDirection = Direction.downLeft;
            
        }
    }

    void Update()
    {
        if (transform.position.y > maxY && runDirection == Direction.upLeft)
        {
            UpdateRunDirection();
        }
        
        if (transform.position.y < minY && runDirection == Direction.downLeft)
        {
            UpdateRunDirection();
        }

        if (runDirection == Direction.upLeft)
        {
            transform.position += new Vector3(-Global.RoomSpeed * 2 * Time.deltaTime, Global.RoomSpeed * 2 * Time.deltaTime, 0);
        }

        if (runDirection == Direction.downLeft)
        {
            transform.position += new Vector3(-Global.RoomSpeed * 2 * Time.deltaTime, -Global.RoomSpeed * 2 * Time.deltaTime, 0);
        }
    }
}
