using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SpawnerStateEnum
{
    RandomSpawning,
    TimelineSpawning,
    RoomSpawning
}

public class EnemySpawner : MonoBehaviour
{
    private Dictionary<SpawnerStateEnum, SpawnerState> spawner = new();

    private SpawnerStateEnum state = SpawnerStateEnum.RandomSpawning;

    private void Start()
    {
        Global.enemySpawner = this;
        spawner.Add(SpawnerStateEnum.RandomSpawning, GetComponent<RandomSpawningState>());
        spawner.Add(SpawnerStateEnum.TimelineSpawning, GetComponent<TimelineSpawningState>());
        spawner.Add(SpawnerStateEnum.RoomSpawning, GetComponent<RoomSpawningState>());
    }

    public void StartGame()
    {
        ChangeState(SpawnerStateEnum.RandomSpawning);
    }

    public void UpdateState()
    {
        // todo select new random state
    }

    private void ChangeState(SpawnerStateEnum s)
    {
        state = s;
        spawner[state].StartSpawner();
    }

}
