using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceEvent
{
    public float distance;
    public Action action;

    public DistanceEvent(Action action, float distance)
    {
        this.distance = distance;
        this.action = action;
    }   
}

public class DistanceManager : Manager
{
    public TextMeshProUGUI distanceText;
    private List<DistanceEvent> distanceEvents = new List<DistanceEvent>();
    private float distance = 0;

    private void Start()
    {
        UpdateDistanceText();
    }

    public void AddDistanceAction(Action action_, float distance_)
    {
        distanceEvents.Add(new DistanceEvent(action_, distance_));
        distanceEvents.Sort((a, b) => a.distance.CompareTo(b.distance));
    }

    private void CheckDistanceActions()
    {
        List<DistanceEvent> updatedEvents = new List<DistanceEvent>();
        foreach (DistanceEvent de in distanceEvents)
        {
            if (de.distance < distance)
            {
                updatedEvents.Add(de);
            }
            else
            {
                de.action();
            }
        }
        distanceEvents = updatedEvents;
        distanceEvents.Sort((a, b) => a.distance.CompareTo(b.distance));
    }

    protected override void SetManager()
    {
        Managers.distanceManager = this;
    }

    public float GetDistance()
    {
        return distance;
    }

    private void UpdateDistanceText()
    {
        distanceText.text = ("Distance: " + ((int)distance).ToString() + "m");
    }

    private void Update()
    {
        distance += (Time.smoothDeltaTime * Global.RoomSpeed * 0.25f);
        if ((int)distance % 10 == 0)
        {
            CheckDistanceActions();
        }
        UpdateDistanceText();
    }
}
