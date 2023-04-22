using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    // Player
    public static float playerMovespeed = 5.0f;
    public static float dashPower = 5.0f;
    public static float dashTimer = 0.15f;
    public static float dashCooldown = 1.0f;
    public static float shootCooldown = 0.5f;
}

public static class Global
{
    public static float RoomSpeed = 5.0f;
    public static AlarmManager alarmManager;
}