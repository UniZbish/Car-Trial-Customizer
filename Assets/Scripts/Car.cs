using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car/Car")]
public class Car : ScriptableObject
{
    public CarBodies body;
    public CarPaint paintJob;
    public List<CarAddOn> addons;

    public int maxSpeed;
    public int handling;
    public int acceleration;
    public int coolness;

}
