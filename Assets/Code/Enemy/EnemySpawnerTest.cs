using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest : MonoBehaviour
{
    public float spawnTimerMin;
    public float spawnTimerMax;
    public Transform BoundsRefTop;
    public Transform BoundsRefBot;

    [Space(15.0f)]
    public List<GameObject> enemies = new List<GameObject>();

    public void StartSpawner()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimerMin, spawnTimerMax));
        GameObject enemy = enemies[Random.Range(0, enemies.Count)];
        Instantiate(enemy, new Vector2(BoundsRefTop.position.x, Random.Range(BoundsRefBot.position.y, BoundsRefTop.position.y)), Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
}
