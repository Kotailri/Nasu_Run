using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnerItem
    {
        public GameObject item;
        public int percentChance;
    }

    public List<SpawnerItem> items = new List<SpawnerItem>();

    private void Start()
    {
        Global.itemSpawner = this;
    }

    public void StartSpawner()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        foreach (SpawnerItem item in items)
        {
            if (Random.Range(0,101) <= item.percentChance)
            {
                Managers.spawnManager.InstantiateRoomObject(item.item);
                break;
            }
        }
        StartCoroutine(SpawnItem());
    }
}
