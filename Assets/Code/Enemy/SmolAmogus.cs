using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmolAmogus : Enemy
{
    public override void OnDeath()
    {
        Destroy(gameObject);
    }
}
