using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    Vector2 minBound;
    Vector2 maxBound;
    private void Start()
    {
        minBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        if ((transform.position.x >= maxBound.x + 5)
         || (transform.position.x <= minBound.x - 5)
         || (transform.position.y >= maxBound.y + 5)
         || (transform.position.y <= minBound.y - 5))
        {
            Destroy(gameObject);
        }
        
    }
}
