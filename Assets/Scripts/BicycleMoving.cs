using UnityEngine;

public class BicycleMoving : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void Awake()
    {
        EventManager.Instance.speedChanged += (newSpeed) => ChangeSpeed(newSpeed);
    }
    private void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
    private void Move()
    {
        Vector3 offset = Vector3.right * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void Update()
    {
        Move();
    }
}
