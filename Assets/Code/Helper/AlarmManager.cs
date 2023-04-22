using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    private List<Alarm> timers = new List<Alarm>();

    public void AddTimer(Alarm t)
    {
        timers.Add(t);
    }

    private void Awake()
    {
        Global.alarmManager = this;
    }

    void Update()
    {
        foreach(Alarm t in timers)
        {
            t.IncrementTime(Time.deltaTime);
        }
    }
}
