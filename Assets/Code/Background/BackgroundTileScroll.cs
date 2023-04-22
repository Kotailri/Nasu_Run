using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTileScroll : MonoBehaviour
{
    public Transform leftTile;

    void Update()
    {
        if (transform.position.x <= -36)
        {
            transform.position = new Vector3(leftTile.position.x + 18f, transform.position.y, transform.position.z);
        }

        transform.position += new Vector3(-Global.RoomSpeed * Time.deltaTime, 0, 0);
    }
}
