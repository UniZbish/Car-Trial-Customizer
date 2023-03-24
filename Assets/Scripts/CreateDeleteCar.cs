using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDeleteCar : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultCar, carHolder;
    private int i;

    public void Start()
    {
        GameEventsPublisher.current.OnCreateNewCar += CreateNewCar;
    }

    private void CreateNewCar()
    {
        i++;
        GameObject temp = Instantiate(defaultCar, carHolder.transform.position, carHolder.transform.rotation);
        temp.GetComponent<VehicleStats>().id = i; 
        GameEventsPublisher.current.CreatedNewCar(temp);
    }

    public void OnDestroy()
    {
        GameEventsPublisher.current.OnCreateNewCar -= CreateNewCar;
    }
}
