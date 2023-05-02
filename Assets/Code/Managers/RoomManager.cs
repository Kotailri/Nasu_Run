using System.Collections;
using UnityEngine;

public class RoomManager : Manager
{ 
    public float roomSpeedIncrement;
    public float roomSpeedIncrementTimer;

    protected override void SetManager()
    {
        Managers.roomManager = this;
    }

    public void StartSpeedup()
    {
        StartCoroutine(IncrementSpeed());
    }

    public void StopSpeedup()
    {
        StopAllCoroutines();
    }

    private IEnumerator IncrementSpeed()
    {
        yield return new WaitForSeconds(roomSpeedIncrementTimer);
        Global.RoomSpeed += roomSpeedIncrement;
        StartCoroutine(IncrementSpeed());
    }
}
