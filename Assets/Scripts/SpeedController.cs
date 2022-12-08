using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _directionPosition;
    private float _speed;

    private void Awake()
    {
        _speed = 3f;
        GameManager.Instance.TouchBeganUser += (position) => SetStartPosition(position);
        GameManager.Instance.TouchMovedUser += (position) => SetDirectionPosition(position);

    }
    private void SetStartPosition(Vector3 position)
    {
        _startPosition = Camera.main.ScreenToWorldPoint(position);
    }
    private void SetDirectionPosition(Vector3 position)
    {
        _directionPosition = Camera.main.ScreenToWorldPoint(position);
        print(_directionPosition);
        CalculateSpeed();
    }
    private void CalculateSpeed()
    {
        //if()
    }
    private void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
