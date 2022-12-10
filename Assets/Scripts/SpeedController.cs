using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _directionPosition;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private const float _maxSpeed = 9f;
    [SerializeField]
    private const float _minSpeed = 1f;

    private void Awake()
    {
        _speed = 3f;
        GameManager.Instance.TouchBeganUser += (position) => SetStartPosition(position);

        GameManager.Instance.TouchMovedUser += (position) => SetDirectionPosition(position);

    }

    private void SetStartPosition(Vector2 posititon)
    {
        _startPosition = posititon;
    }
    private void SetDirectionPosition(Vector2 posititon)
    {
        _directionPosition = posititon;
        CheckSpeedChange();
    }

    private void CheckSpeedChange()
    {
        if (_directionPosition.x == _startPosition.x)
            return;

        if (_directionPosition.x > _startPosition.x)
            SetSpeed(_speed + 0.05f);
        else
            SetSpeed(_speed - 0.05f);
    }
    private void SetSpeed(float newSpeed)
    {
        if (newSpeed >= _minSpeed && newSpeed <= _maxSpeed)
        {
            _speed = newSpeed;
            EventManager.Instance.OnSpeedChanged(_speed);
        }
    }
}
