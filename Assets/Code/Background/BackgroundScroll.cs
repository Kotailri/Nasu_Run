using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed;
    public bool basedOffRoomSpeed = false;
    private float length;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (Global.RoomSpeed == 0)
            return;

        if (basedOffRoomSpeed)
        {
            float newPosition = Mathf.Repeat(Time.time * -scrollSpeed * (Global.RoomSpeed/5.0f), length);
            transform.position = new Vector2(newPosition, transform.position.y);
        }
        else
        {
            float newPosition = Mathf.Repeat(Time.time * -scrollSpeed, length);
            transform.position = new Vector2(newPosition, transform.position.y);
        }
        
    }
}
