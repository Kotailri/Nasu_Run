using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    protected abstract void SetManager();

    private void Awake()
    {
        SetManager();
    }
}
