using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : Manager
{
    public TextMeshProUGUI distanceText;

    private float distance = 0;

    private void Start()
    {
        UpdateDistanceText();
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
        UpdateDistanceText();
    }
}
