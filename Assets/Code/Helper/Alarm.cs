public class Alarm
{
    private float maxTimer;
    private float currentTimer;
    private bool isTimerRunning;
    private bool isTimerPaused;
    
    public Alarm(float time, bool startsAtZero=false)
    {
        maxTimer = time;
        isTimerPaused = false;
        isTimerRunning = false;

        if (startsAtZero)
            ResetTimer();

        Managers.alarmManager.AddTimer(this);
    }

    public bool IsAvailable()
    {
        return !isTimerRunning;
    }

    public float GetTimerPercent()
    {
        if (IsAvailable())
            return 1.0f;

        return (float)currentTimer / (float)maxTimer;
    }

    public void IncrementTime(float time)
    {
        if (!isTimerRunning || isTimerPaused)
            return;

        currentTimer += time;
        if (currentTimer >= maxTimer)
            isTimerRunning = false;
    }

    public void UnpauseTimer()
    {
        isTimerPaused = false;
    }

    public void PauseTimer()
    {
        isTimerPaused = true;
    }

    public void ResetTimer()
    {
        currentTimer = 0;
        isTimerRunning = true;
    }
}
