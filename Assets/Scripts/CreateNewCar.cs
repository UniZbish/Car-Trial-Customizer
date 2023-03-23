using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCar : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultCar, carHolder;

    public void Start()
    {
        GameEventsPublisher.current.OnCreateNewCar += Current_OnCreateNewCar;
    }

    private void Current_OnCreateNewCar()
    {
        GameObject temp = Instantiate(defaultCar, carHolder.transform.position, carHolder.transform.rotation);
        GameEventsPublisher.current.CreatedNewCar(temp);
    }

    public void OnDestroy()
    {
        GameEventsPublisher.current.OnCreateNewCar -= Current_OnCreateNewCar;
    }
}
