using UnityEngine;

public class SpawnClefBurst : MonoBehaviour
{
    public void ClefBurst(int numClefs)
    {
        GameObject burst = Instantiate(Resources.Load<GameObject>("ClefBurst"), transform.position, Quaternion.identity);
        burst.GetComponent<ClefBurst>().numClefs = numClefs;
        burst.GetComponent<ClefBurst>().Create();
    }
}
