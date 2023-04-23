using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : Manager
{
    private List<Alarm> timers = new List<Alarm>();

    public void AddTimer(Alarm t)
    {
        timers.Add(t);
    }

    protected override void SetManager()
    {
        Managers.alarmManager = this;
    }

    void Update()
    {
        foreach(Alarm t in timers)
        {
            t.IncrementTime(Time.deltaTime);
        }
    }
}
