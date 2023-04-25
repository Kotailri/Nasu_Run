using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform BoundsRefTop;
    public Transform BoundsRefBot;

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
        yield return new WaitForSeconds(Random.Range(5, 15));
        foreach (SpawnerItem item in items)
        {
            if (Random.Range(0,101) <= item.percentChance)
            {
                Instantiate(item.item, new Vector2(BoundsRefTop.position.x, Random.Range(BoundsRefBot.position.y, BoundsRefTop.position.y)), Quaternion.identity);
                break;
            }
        }
        StartCoroutine(SpawnItem());
    }
}
