using UnityEngine;

public class BoundsRefManager : Manager
{
    public Transform topref;
    public Transform botref;

    private Vector2 topBounds;
    private Vector2 botBounds;

    protected override void SetManager()
    {
        topBounds = topref.position;
        botBounds = botref.position;
        Managers.boundsRefManager = this;
    }

    public Vector2 GetBoundsRefTop()
    {
        return topBounds;
    }

    public Vector2 GetBoundsRefBot()
    {
        return botBounds;
    }

    public float GetMaxY()
    {
        return topBounds.y;
    }

    public float GetMinY()
    {
        return botBounds.y;
    }

    public float GetX()
    {
        return topBounds.x;
    }
}
