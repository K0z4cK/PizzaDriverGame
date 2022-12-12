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

    private Queue<Transform> _carsPool;

    private int _poolSize;

    private int _direction;

    private bool _isApplicationEnd = false; //костиль, не придумав як прибрати ерори які викликаються при завершенні гри

    private void Awake()
    {
        EventManager.Instance.gameLosed += OnApplicationQuit;
        EventManager.Instance.gameWined += OnApplicationQuit;

        _carsPool = new Queue<Transform>();
        _poolSize = 5; 
        _direction = (Random.Range(0, 10) >= 5) ? 1 : -1;
        _startPoint.transform.localPosition = new Vector3(this.transform.localScale.x/2 * _direction, _startPoint.transform.position.y, _startPoint.transform.position.z);
        _endPoint.transform.localPosition = new Vector3(this.transform.localScale.x / 2 * -_direction, _endPoint.transform.position.y, _endPoint.transform.position.z);

        do {
            var newCar = Instantiate(_carPrefab, _startPoint.transform.position, _carPrefab.rotation);
            _carsPool.Enqueue(newCar);
            newCar.GetComponent<Car>().SetDirection(_direction);
            DeactivateCar();
        } while (_carsPool.Count != _poolSize);

    }

    private void DeactivateCar()
    {
        _carsPool.Peek().gameObject.SetActive(false);
        _carsPool.Enqueue(_carsPool.Dequeue());
    }
    public void ResetCar()
    {
        _carsPool.Peek().position = _startPoint.transform.position;
        _carsPool.Peek().gameObject.SetActive(true);
        _carsPool.Enqueue(_carsPool.Dequeue());
    }
    private IEnumerator StartTrafficCoroutine()
    {
        for (int i = 0; i < _carsPool.Count; i++)
        {
            ResetCar();
            yield return new WaitForSeconds(1f);

        }
    }

    private void OnDisable()
    {
        if (_isApplicationEnd)
            return;
        StopCoroutine(StartTrafficCoroutine());
        for (int i = 0; i < _carsPool.Count; i++)
        {
            DeactivateCar();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartTrafficCoroutine());
    }
    private void OnApplicationQuit()
    {
        _isApplicationEnd = true;
    }
}
