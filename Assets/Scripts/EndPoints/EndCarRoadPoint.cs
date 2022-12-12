using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCarRoadPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car Road")
        {
            EventManager.Instance.OnCarRoadDisabled();
        }
    }
}
