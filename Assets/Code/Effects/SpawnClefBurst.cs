using UnityEngine;

public class SpawnClefBurst : MonoBehaviour
{
    public void ClefBurst()
    {
        Instantiate(Resources.Load<GameObject>("ClefBurst"), transform.position, Quaternion.identity);
    }
}
