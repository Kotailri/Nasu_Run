using System.Collections;
using System.Collections.Generic;
using System.Transactions;
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
        public int minDistance;

        [Space(10.0f)]
        public float spawnTimerMin;
        public float spawnTimerMax;

        [Space(10.0f)]
        public List<EnemySpawn> enemies = new();
    }

    public List<EnemySpawnSet> enemiesSet = new();
    private EnemySpawnSet currentSet;

    public override void StartSpawner()
    {
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
    }

    private IEnumerator SpawnEnemy(float spawnTimerMin, float spawnTimerMax)
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
