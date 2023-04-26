using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawn
    {
        public GameObject enemy;
        public float minDistance;
        public float chance;
    }

    public float spawnTimerMin;
    public float spawnTimerMax;
    public Transform BoundsRefTop;
    public Transform BoundsRefBot;

    [Space(15.0f)]
    public List<EnemySpawn> enemies = new List<EnemySpawn>();

    private void Start()
    {
        Global.enemySpawner = this;
    }

    public void StartSpawner()
    {
        enemies.Sort((a, b) => a.minDistance.CompareTo(b.minDistance));
        enemies.Reverse();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimerMin, spawnTimerMax));
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Managers.distanceManager.GetDistance() >= enemies[i].minDistance && Random.Range(0, 101) <= enemies[i].chance)
            {
                GameObject enemy = enemies[i].enemy;
                Managers.spawnManager.InstantiateRoomObject(enemy);
                break;
            }
        }
        StartCoroutine(SpawnEnemy());
    }
}
