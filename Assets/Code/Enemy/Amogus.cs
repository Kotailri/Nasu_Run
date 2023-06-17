using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amogus : Enemy
{
    private float maxY;
    private float minY;

    public float runSpeed;
    private Direction runDirection;

    private enum Direction
    {
        downLeft,
        upLeft
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        Vector3 spriteBounds = bc.bounds.size;
        maxY = Managers.boundsRefManager.GetMaxY() + spriteBounds.y / 2;
        minY = Managers.boundsRefManager.GetMinY() - spriteBounds.y / 2;

        if (Random.Range(0,2) == 0)
        {
            runDirection = Direction.downLeft;
        }
        else
        {
            runDirection = Direction.upLeft;
        }
        
        UpdateRunDirection();
    }

    private void UpdateRunDirection()
    {
        if (runDirection == Direction.downLeft) 
        {
            runDirection = Direction.upLeft;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1).normalized * runSpeed;
        }
        else if (runDirection == Direction.upLeft)
        {
            runDirection = Direction.downLeft;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1).normalized * runSpeed;
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
    }
}
