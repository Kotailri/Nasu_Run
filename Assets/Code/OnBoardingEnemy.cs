using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingEnemy : MonoBehaviour
{
    private void Start()
    {
        Global.RoomSpeed = 1;
        Utility.InvokeLambda(() => { 
            GetComponent<Moyai>().OnDeath();
        }, 0.05f);
    }

    private void OnDisable()
    {
        if (Global.enemySpawner != null)
            Global.enemySpawner.GetComponent<EnemySpawner>().StartSpawner();
        if (Global.itemSpawner != null)
            Global.itemSpawner.StartSpawner();
        Global.RoomSpeed = Config.defaultRoomSpeed;
    }
}
