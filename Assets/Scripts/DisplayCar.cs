using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCar : MonoBehaviour
{
    public List<GameObject> cars;
    public GameObject selectedCar;

    private GameObject holder;

    [SerializeField]
    private UIUpdater UIScript;

    // Start is called before the first frame update
    void Start()
    {
        GameEventsPublisher.current.OnCreatedNewCar += Current_OnCreatedNewCar;
        GameEventsPublisher.current.OnEditButtonClick += Current_OnEditButtonClick; ;
        holder = GameObject.Find("SelectedCarHolder");
    }

    private void Current_OnEditButtonClick(int index)
    {
        DisplayTheCar(cars[index]);
    }

    private void Current_OnCreatedNewCar(GameObject obj)
    {
        cars.Add(obj);
        DisplayTheCar(obj);
    }

    private void DisplayTheCar(GameObject car)
    {
        if (selectedCar != null)
        {
            selectedCar.SetActive(false);
        }

        selectedCar = car;
        selectedCar.SetActive(true);
    }

    public void ChangeCar(int dropDownValue) 
    {
        //for (int i = 0; i < holder.transform.childCount; i++)
        //{
        //    Destroy(holder.transform.GetChild(i).gameObject);
        //}
        //
        //selectedCar = carsToDisplay[dropDownValue];
        //carModel = Instantiate(selectedCar.body.carModel, holder.transform);
        //ApplyMaterial(carModel);
    }

    public void ApplyMaterial(GameObject car)
    {
        //car.GetComponent<MeshRenderer>().material = selectedCar.GetComponent<>.material;
        //UIScript.UpdateTheUI(selectedCar);
    }
}
