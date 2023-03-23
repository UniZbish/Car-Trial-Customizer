using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleStats : MonoBehaviour
{
    public Car carObject;

    private void Start()
    {
        RefreshStats(false);
    }

    public void RefreshStats(bool addons)
    {
        carObject.maxSpeed      = 0;
        carObject.handling      = 0;
        carObject.acceleration  = 0;
        carObject.coolness      = 0;

        carObject.maxSpeed     = carObject.body.changeSpeed         += carObject.paintJob.changeSpeed;
        carObject.handling     = carObject.body.changeHandling      += carObject.paintJob.changeHandling;
        carObject.acceleration = carObject.body.changeAcceleration  += carObject.paintJob.changeAcceleration;
        carObject.coolness     = carObject.body.changeCoolness      += carObject.paintJob.changeCoolness;

        if (addons)
        {
            foreach (CarAddOn addon in carObject.addons)
            {
                carObject.maxSpeed      += addon.changeSpeed;
                carObject.handling      += addon.changeHandling;
                carObject.acceleration  += addon.changeAcceleration;
                carObject.coolness      += addon.changeCoolness;
            }
        }
    }
}
