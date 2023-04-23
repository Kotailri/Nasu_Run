using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObjectScroll : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(Global.RoomSpeed * Time.deltaTime, 0, 0);
    }
}
