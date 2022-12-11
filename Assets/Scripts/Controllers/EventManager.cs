using UnityEngine;

[DisallowMultipleComponent]
public class EventManager : SingletonComponent<EventManager>
{

    public delegate void SpeedChanged(float speed);
    public event SpeedChanged speedChanged;

    public delegate void CarRoadDisabled();
    public event CarRoadDisabled carRoadDisabled;

    public void OnSpeedChanged(float speed)
    {
         speedChanged?.Invoke(speed);
    }
    public void OnCarRoadDisabled()
    {
        carRoadDisabled?.Invoke();
    }
}