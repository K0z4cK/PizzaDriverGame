using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Game Win
        if (other.tag == "Player")
        {
            EventManager.Instance.OnGameWin();
        }
        else if (other.tag == "Spawner")
        {
            EventManager.Instance.OnStopSpawning();
        }

    }
}
