using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObjectScroll : MonoBehaviour
{

    public float speedMultiplier;

    void Update()
    {
        if (speedMultiplier != 0)
        {
            transform.position -= new Vector3(Global.RoomSpeed * speedMultiplier * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(Global.RoomSpeed * Time.deltaTime, 0, 0);
        }
        
    }
}
