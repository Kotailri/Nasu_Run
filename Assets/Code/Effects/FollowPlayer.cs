using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform follow;
    public Vector3 offset = Vector3.zero;

    void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = follow.position + offset;
    }
}
