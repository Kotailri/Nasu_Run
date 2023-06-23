using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    // Player
    public static float playerMovespeed = 8.0f;
    public static float dashPower = 3.0f;
    public static float dashTimer = 0.15f;
    public static float dashCooldown = 0.5f;
    public static float shootCooldown = 0.5f;

    public static float defaultRoomSpeed = 2.0f;

    public static float soundVolume = 0.75f;
}

public static class Global
{
    public static float RoomSpeed = 0.0f; // DON'T CHANGE
    public static ItemSpawner itemSpawner;
    public static EnemySpawner enemySpawner;
    public static BoundsRefManager boundsRefManager;
}

public static class Managers
{
    public static AlarmManager alarmManager;
    public static ScoreManager scoreManager;
    public static DistanceManager distanceManager;
    public static RoomManager roomManager;
    public static SpawnManager spawnManager;
    public static AudioManager audioManager;
    public static SpawnText textSpawnerManager;
}