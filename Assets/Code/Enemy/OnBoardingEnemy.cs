using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoardingEnemy : MonoBehaviour
{
    public GameObject tutorialInfo;

    private void Start()
    {
        Global.RoomSpeed = 0;
        tutorialInfo.SetActive(false);
        Utility.InvokeLambda(() => { 
            GetComponent<Moyai>().OnDeath();
        }, 0.05f);
    }

    private void OnDisable()
    {
        if (Global.enemySpawner != null)
            Global.enemySpawner.GetComponent<EnemySpawner>().StartGame();
        if (Global.itemSpawner != null)
            Global.itemSpawner.StartSpawner();
        if (Managers.roomManager != null)
            Managers.roomManager.StartSpeedup();
        Global.RoomSpeed = Config.defaultRoomSpeed;
        if (tutorialInfo != null)
            tutorialInfo.SetActive(true);
    }
}
