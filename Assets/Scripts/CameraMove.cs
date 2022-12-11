using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform _bicycle;

    private Vector3 _remoteness;

    private void Awake()
    {
        _remoteness = _bicycle.position - this.transform.position;
    }

    private void Update()
    {
        this.transform.position = new Vector3(_bicycle.position.x - _remoteness.x, _bicycle.position.y - _remoteness.y, _bicycle.position.z);
    }
}
