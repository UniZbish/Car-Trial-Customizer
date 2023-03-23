using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCarMaterial : MonoBehaviour
{
    private DisplayCar displayCarScript;
    private Car currentCar;

    private void Start()
    {
        displayCarScript = GetComponent<DisplayCar>();
    }

    public void MaterialChange(CarPaint newMaterial)
    {
        currentCar = displayCarScript.selectedCar;
        RemoveOldStats();
        currentCar.paintJob = newMaterial;
        ApplyNewStats();
        displayCarScript.ApplyMaterial(displayCarScript.carModel);
    }

    public void RemoveOldStats()
    {
        currentCar.maxSpeed     -= currentCar.paintJob.changeSpeed;
        currentCar.handling     -= currentCar.paintJob.changeHandling;
        currentCar.acceleration -= currentCar.paintJob.changeAcceleration; 
        currentCar.coolness     -= currentCar.paintJob.changeCoolness;
    }

    public void ApplyNewStats()
    {
        currentCar.maxSpeed     += currentCar.paintJob.changeSpeed;
        currentCar.handling     += currentCar.paintJob.changeHandling;
        currentCar.acceleration += currentCar.paintJob.changeAcceleration;
        currentCar.coolness     += currentCar.paintJob.changeCoolness;
    }
}
