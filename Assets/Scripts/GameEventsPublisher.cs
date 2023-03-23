using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsPublisher : MonoBehaviour
{
    public static GameEventsPublisher current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnCreateNewCar;
    public void CreateNewCar()
    {
        OnCreateNewCar?.Invoke();
    }

    public event Action<GameObject> OnCreatedNewCar;
    public void CreatedNewCar(GameObject newCar) 
    {
        OnCreatedNewCar?.Invoke(newCar);
    }

    public event Action<int> OnEditButtonClick;
    public void EditCar(int id) 
    {
        OnEditButtonClick?.Invoke(id);
    }

    public event Action<Car> OnDisplayCar;
    public void DisplayedCar(Car car)
    {
        OnDisplayCar?.Invoke(car);
    }

}
