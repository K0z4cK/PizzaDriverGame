using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRoad : MonoBehaviour
{
    [SerializeField]
    private Transform _carPrefab;
    [SerializeField]
    private Collider _startPoint;
    [SerializeField]
    private Collider _endPoint;
    [SerializeField]
    private Queue<Transform> _carsPool;

    private int _poolSize;

    private int _direction;

    private void Awake()
    {
        _carsPool = new Queue<Transform>();
        _poolSize = 10; 
        _direction = (Random.Range(0, 10) >= 5) ? 1 : -1;
        _startPoint.transform.localPosition = new Vector3(this.transform.localScale.x/2 * _direction, _startPoint.transform.position.y, _startPoint.transform.position.z);
        _endPoint.transform.localPosition = new Vector3(this.transform.localScale.x / 2 * -_direction, _endPoint.transform.position.y, _endPoint.transform.position.z);

        do {
            var newCar = Instantiate(_carPrefab, _startPoint.transform.position, _carPrefab.rotation);
            _carsPool.Enqueue(newCar);
            newCar.GetComponent<Car>().SetDirection(_direction);
            DeactivateCar(newCar);
        } while (_carsPool.Count != _poolSize);

        StartCoroutine(StartTrafficCoroutine());
    }

    private void DeactivateCar(Transform car)
    {
        car.gameObject.SetActive(false);
    }
    public void ResetCar(Transform car)
    {
        car.position = _startPoint.transform.position;
    }
    private IEnumerator StartTrafficCoroutine()
    {
        for (int i = 0; i < _carsPool.Count; i++)
        {
            _carsPool.Peek().gameObject.SetActive(true);
            _carsPool.Enqueue(_carsPool.Peek());
            _carsPool.Dequeue();
            yield return new WaitForSeconds(2f); 
        }
    }
}
