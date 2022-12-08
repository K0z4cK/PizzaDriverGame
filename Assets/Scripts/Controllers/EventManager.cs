using UnityEngine;

[DisallowMultipleComponent]
public class EventManager : SingletonComponent<EventManager>
{

    public delegate void SpeedChanged(float speed);
    public event SpeedChanged speedChanged;

    public void onSpeedChanged(float speed)
    {
         speedChanged?.Invoke(speed);
    }
}