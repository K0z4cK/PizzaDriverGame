using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject _car;

    float right = -0.2f;
    float left = 1.2f;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        Vector3 final = Camera.main.ViewportToWorldPoint(new Vector3(right, 1, 10));

        final.y = _car.transform.position.y;
        Instantiate(_car, final, Quaternion.Euler(0, 180, 0));
        final = Camera.main.ViewportToWorldPoint(new Vector3(left, 1, 10));

        final.y = _car.transform.position.y;
        Instantiate(_car, final, Quaternion.Euler(0, 180, 0));
    }*/
}
