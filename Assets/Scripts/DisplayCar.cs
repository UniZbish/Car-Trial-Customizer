using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCar : MonoBehaviour
{
    private List<GameObject> cars;
    [SerializeField]
    private List<CarPaint> paintJobs;
    [SerializeField]
    private List<CarBodies> carBodies;
    [SerializeField]
    private List<CarAddOn> carAddons;
    public GameObject selectedCar;

    [SerializeField]
    private UIUpdater UIScript;

    // Start is called before the first frame update
    void Start()
    {
        cars = new List<GameObject>();

        GameEventsPublisher.current.OnCreatedNewCar += CreateNewCar;
        GameEventsPublisher.current.OnDeleteCar += DeleteCar;
        GameEventsPublisher.current.OnEditSelectedCar += EditButtonClick;
        GameEventsPublisher.current.OnPaintJobChange += ApplyPaintJob;
    }
    private void DeleteCar(int index)
    {
        GameObject carToDelete = cars[index];
        DisplayTheCar(carToDelete);
        cars.Remove(carToDelete);
        Destroy(selectedCar);
        if(cars.Count != 0) 
        {
            DisplayTheCar(cars[cars.Count - 1]);
        }
    }

    private void EditButtonClick(int index)
    {
        GameObject car = cars[index];
        DisplayTheCar(car);
    }

    private void CreateNewCar(GameObject newCar)
    {
        cars.Add(newCar);
        DisplayTheCar(newCar);
    }

    private void DisplayTheCar(GameObject car)
    {
        if (selectedCar != null)
        {
            selectedCar.SetActive(false);
        }

        selectedCar = car;
        selectedCar.SetActive(true);
        GameEventsPublisher.current.MaterialChanged(selectedCar.GetComponent<VehicleStats>().id);
    }

    public void ApplyPaintJob(int indexToApply)
    {
        CarPaint newPaint = paintJobs[indexToApply];
        selectedCar.GetComponent<VehicleStats>().paintJob = newPaint;
        selectedCar.GetComponent<MeshRenderer>().material = newPaint.material;
        GameEventsPublisher.current.MaterialChanged(selectedCar.GetComponent<VehicleStats>().id);
    }
}
