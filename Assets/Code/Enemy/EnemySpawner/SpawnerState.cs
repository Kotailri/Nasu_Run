using UnityEngine;

public abstract class SpawnerState : MonoBehaviour
{
    public void InvokeSpawnCompletion()
    {
        Global.enemySpawner.UpdateState();
    }

    public abstract void StartSpawner();
}
