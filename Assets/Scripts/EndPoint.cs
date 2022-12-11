using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private CarRoad _carRoadScript;
    private void Awake()
    {
        _carRoadScript = this.transform.parent.GetComponent<CarRoad>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            _carRoadScript.ResetCar();
        }
    }
}
