using UnityEngine;

public class EndCarPoint : MonoBehaviour
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
