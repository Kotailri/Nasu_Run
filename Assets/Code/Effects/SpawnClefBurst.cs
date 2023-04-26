using UnityEngine;

public class SpawnClefBurst : MonoBehaviour
{
    public int numClefsMin;
    public int numClefsMax;
    public void ClefBurst()
    {
        GameObject burst = Instantiate(Resources.Load<GameObject>("ClefBurst"), transform.position, Quaternion.identity);
        burst.GetComponent<ClefBurst>().numClefs = Random.Range(numClefsMin, numClefsMax + 1);
        burst.GetComponent<ClefBurst>().Create();
    }
}
