using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform follow;

    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = follow.position;
    }
}
