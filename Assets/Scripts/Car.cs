using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField] 
    private Rigidbody _rigidbody;

    private Vector3 _direction;

    private void Awake()
    {
        _speed = 20;
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    public void SetDirection (int direction)
    {
        _direction = new Vector3(0, 0, direction);
    }
    private void Move()
    {
        Vector3 offset = _direction * (_speed * Time.deltaTime);
        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void Update()
    {
        Move();
    }
}
