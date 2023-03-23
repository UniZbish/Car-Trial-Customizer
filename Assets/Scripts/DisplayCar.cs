using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCar : MonoBehaviour
{
    public List<Car> carsToDisplay;
    public Car selectedCar;
    public GameObject carModel;

    private GameObject holder;

    [SerializeField]
    private UIUpdater UIScript;

    // Start is called before the first frame update
    void Start()
    {
        //GameEventsPublisher.current.onCreateNewCar += onDisplayCar;
        holder = GameObject.Find("SelectedCarHolder");
        ChangeCar(0);
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
        car.GetComponent<MeshRenderer>().material = selectedCar.paintJob.material;
        //UIScript.UpdateTheUI(selectedCar);
    }
}
