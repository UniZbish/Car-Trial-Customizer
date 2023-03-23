using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car/Car")]
public class Car : ScriptableObject
{
    public CarBodies body;
    public CarPaint paintJob;
    public List<CarAddOn> addons;

    public float maxSpeed;
    public float handling;
    public float acceleration;
    public float coolness;

}
