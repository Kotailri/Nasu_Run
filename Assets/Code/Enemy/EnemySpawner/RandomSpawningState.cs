using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawningState : SpawnerState
{
    [System.Serializable]
    public class EnemySpawn
    {
        public GameObject enemy;
        public float minDistance;
        public float chance;
    }

    [System.Serializable]
    public class EnemySpawnSet
    {
        public int percentChance;
        public float stateTime;
        public int minDistance;

        [Space(10.0f)]
        public float spawnTimerMin;
        public float spawnTimerMax;

        [Space(10.0f)]
        public List<EnemySpawn> enemies = new();
    }

    public List<EnemySpawnSet> enemiesSet = new();
    private EnemySpawnSet currentSet;
    private bool spawnerEnabled = true;

    public override void StartSpawner()
    {
        spawnerEnabled = true;
        int maxIterations = 100;
        enemiesSet.Sort((a, b) => a.percentChance.CompareTo(b.percentChance));
        for (int i = 0; i < maxIterations; i++)
        {
            currentSet = enemiesSet[Random.Range(0, enemiesSet.Count)];
            if (Random.Range(0,101) <= currentSet.percentChance && currentSet.minDistance <= Managers.distanceManager.GetDistance())
            {
                StartCoroutine(SpawnEnemy(currentSet.spawnTimerMin, currentSet.spawnTimerMax));
                return;
            }
        }
        Utility.PrintWarn("Could not find enemy set!");

        currentSet = enemiesSet[0];

        StartCoroutine(SpawnEnemy(currentSet.spawnTimerMin, currentSet.spawnTimerMax));
        //StartCoroutine(StateTimer(currentSet.stateTime));
    }

    private IEnumerator StateTimer(float time)
    {
        yield return new WaitForSeconds(time);
        spawnerEnabled = false;
        yield return new WaitForSeconds(1f);
        InvokeSpawnCompletion();
    }

    private IEnumerator SpawnEnemy(float spawnTimerMin, float spawnTimerMax)
    {
        if (spawnerEnabled)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimerMin, spawnTimerMax));
            for (int i = 0; i < currentSet.enemies.Count; i++)
            {
                if (Random.Range(0, 101) <= currentSet.enemies[i].chance && currentSet.enemies[i].minDistance <= Managers.distanceManager.GetDistance())
                {
                    GameObject enemy = currentSet.enemies[i].enemy;
                    Managers.spawnManager.InstantiateRoomObject(enemy);
                    break;
                }
            }
            StartCoroutine(SpawnEnemy(spawnTimerMin, spawnTimerMax));
        }
    }
}
