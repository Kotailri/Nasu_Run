using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingEnemy : MonoBehaviour
{
    private void Start()
    {
        Utility.InvokeLambda(() => { 
            GetComponent<Moyai>().OnDeath();
        }, 0.25f);
    }

    private void OnDisable()
    {
        GameObject.Find("TestSpawner").GetComponent<EnemySpawnerTest>().StartSpawner();
        Global.itemSpawner.StartSpawner();
    }
}
