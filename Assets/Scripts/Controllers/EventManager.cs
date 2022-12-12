using UnityEngine;

[DisallowMultipleComponent]
public class EventManager : SingletonComponent<EventManager>
{

    public delegate void SpeedChanged(float speed);
    public event SpeedChanged speedChanged;

    public delegate void CarRoadDisabled();
    public event CarRoadDisabled carRoadDisabled;

    public delegate void StopSpawning();
    public event StopSpawning stopSpawning;

    public delegate void GameLose();
    public event GameLose gameLosed;
    public delegate void GameWin();
    public event GameWin gameWined;

    public void OnSpeedChanged(float speed)
    {
         speedChanged?.Invoke(speed);
    }
    public void OnCarRoadDisabled()
    {
        carRoadDisabled?.Invoke();
    }

    public void OnStopSpawning()
    {
        stopSpawning?.Invoke();
    }
    public void OnGameLose()
    {
        gameLosed?.Invoke();
    }
    public void OnGameWin()
    {
        gameWined?.Invoke();
    }
}