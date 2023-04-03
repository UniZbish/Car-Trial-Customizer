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

    public GameObject selectedCar = null;

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
        GameEventsPublisher.current.OnBodyTypeChange += ApplyBodyType;
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

        if (cars.Count == 0) 
        {
            selectedCar = null;
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
        if(selectedCar != null) 
        {
            CarPaint newPaint = paintJobs[indexToApply];
            selectedCar.GetComponent<VehicleStats>().paintJob = newPaint;
            selectedCar.GetComponentInChildren<MeshRenderer>().material = newPaint.material;
            GameEventsPublisher.current.MaterialChanged(selectedCar.GetComponent<VehicleStats>().id);
        }
    }
    private void ApplyBodyType(int indexToApply)
    {
        if (selectedCar != null) 
        {
            CarBodies newBody = carBodies[indexToApply];
            selectedCar.GetComponent<VehicleStats>().body = newBody;
            DestroyCarModel();
            InstantiateNewCarModel(newBody.carModel);
            GameEventsPublisher.current.BodyTypeChanged(selectedCar.GetComponent<VehicleStats>().id);
        }
    }

    private void DestroyCarModel() 
    {
        Destroy(selectedCar.transform.Find("PlayerCar").gameObject);
    }

    private void InstantiateNewCarModel(GameObject model)
    {
        GameObject temp = Instantiate(model, selectedCar.transform);
        temp.name = "PlayerCar";
    }
}
