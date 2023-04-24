using UnityEngine;

public class StunEffect : MonoBehaviour
{
    public Vector3 spawnLocation;
    public Transform parent;
    private GameObject stunObject;

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("StunEffect");
        stunObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        stunObject.transform.SetParent(parent, false);
        DisableStunEffect();
    }

    public void EnableStunEffect()
    {
        stunObject.SetActive(true);
        stunObject.transform.localPosition = spawnLocation;
    }

    public void DisableStunEffect()
    {
        stunObject.SetActive(false);
    }
}
