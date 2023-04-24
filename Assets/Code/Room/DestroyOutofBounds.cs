using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    public bool minX;
    public bool maxX;

    [Space(10.0f)]
    public bool minY;
    public bool maxY;

    private Vector2 minBound;
    private Vector2 maxBound;

    private void Start()
    {
        minBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        if (transform.position.x >= maxBound.x + 5 && maxX)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= minBound.x - 5 && minX)
        {
            Destroy(gameObject);
        }

        if (transform.position.y >= maxBound.y + 5 && maxY)
        {
            Destroy(gameObject);
        }

        if (transform.position.y <= minBound.y - Global.RoomSpeed && minY)
        {
            Destroy(gameObject);
        }
    }
}
