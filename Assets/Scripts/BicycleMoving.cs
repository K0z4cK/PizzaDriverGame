using UnityEngine;

public class BicycleMoving : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    public void Move()
    {
        Vector3 offset = Vector3.right * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void Update()
    {
        Move();
    }
}
