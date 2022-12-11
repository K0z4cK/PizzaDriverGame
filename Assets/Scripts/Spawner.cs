using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _carRoadPrefab;
    [SerializeField]
    private Transform _housePrefab;
    [SerializeField]
    private Transform _treePrefab;
    [SerializeField]
    private MeshCollider _rightSpawpArea;
    [SerializeField]
    private MeshCollider _leftSpawpArea;
    [SerializeField]
    private MeshCollider _carRoadSpawPoint;

    [SerializeField]
    private int _carRoadPoolSize = 3;
    [SerializeField]
    private int _environmentPoolSize = 10;

    private Queue<Transform> _carRoadsPool;
    private Queue<Transform> _environmentPool;

    private float _spawnX, _spawnZ;


    private void Awake()
    {
        EventManager.Instance.carRoadDisabled += ResetCarRoad;
        _environmentPool = new Queue<Transform>();
        do
        {
            var instance = (Random.Range(0, 10) > 5) ? _housePrefab : _treePrefab;
            var newEnvironment = Instantiate(instance, instance.position, instance.rotation);
            _environmentPool.Enqueue(newEnvironment);
        } while (_environmentPool.Count != _environmentPoolSize);

        _carRoadsPool = new Queue<Transform>();
        do
        {
            var newCarRoad = Instantiate(_carRoadPrefab, this.transform.position, _carRoadPrefab.rotation);
            _carRoadsPool.Enqueue(newCarRoad);
        } while (_carRoadsPool.Count != _carRoadPoolSize);     
        StartCoroutine(SpawnCoroutine());
    }
    private void SpawnCarRoad()
    {
        _carRoadsPool.Peek().position = _carRoadSpawPoint.gameObject.transform.position;
        _carRoadsPool.Peek().gameObject.SetActive(true);
        _carRoadsPool.Enqueue(_carRoadsPool.Dequeue());
    }
    private void SpawnEnvironment(MeshCollider side)
    {
        _spawnX = Random.Range(side.bounds.min.x, side.bounds.max.x);
        _spawnZ = Random.Range(side.bounds.min.z, side.bounds.max.z);
        _environmentPool.Peek().position = new Vector3(_spawnX, _environmentPool.Peek().position.y, _spawnZ);
        _environmentPool.Peek().gameObject.SetActive(true);
        _environmentPool.Enqueue(_environmentPool.Dequeue());
    }
    private void ResetCarRoad()
    {
        SpawnEnvironment(_leftSpawpArea);
        SpawnEnvironment(_rightSpawpArea);
        SpawnCarRoad();
    }
    private IEnumerator SpawnCoroutine()
    {
        do
        {
            ResetCarRoad();
            yield return new WaitForSeconds(5f);
        }while (true);
    }
}
