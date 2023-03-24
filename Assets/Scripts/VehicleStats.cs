using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleStats : MonoBehaviour
{
    public CarBodies body;
    public CarPaint paintJob;
    public List<CarAddOn> addons;

    public float maxSpeed;
    public float handling;
    public float acceleration;
    public float coolness;

    public int id;

    private void Start()
    {
        GameEventsPublisher.current.OnMaterialChanged += RefreshStats;
        
        RefreshStats(id);
    }

    public void RefreshStats(int providedId)
    {
        if (id == providedId)
        {
            maxSpeed = 0;
            handling = 0;
            acceleration = 0;
            coolness = 0;

            maxSpeed += body.changeSpeed + paintJob.changeSpeed;
            handling += body.changeHandling + paintJob.changeHandling;
            acceleration += body.changeAcceleration + paintJob.changeAcceleration;
            coolness += body.changeCoolness + paintJob.changeCoolness;

            foreach (CarAddOn addon in addons)
            {
                maxSpeed += addon.changeSpeed;
                handling += addon.changeHandling;
                acceleration += addon.changeAcceleration;
                coolness += addon.changeCoolness;
            }
            GameEventsPublisher.current.DisplayCarStats(this);
        }
    }

    private void OnDestroy()
    {
        GameEventsPublisher.current.OnMaterialChanged -= RefreshStats;
    }
}
