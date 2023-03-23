using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Addon", menuName = "Car/Car Parts/Addon")]
public class CarAddOn : ScriptableObject
{
    public GameObject model;

    public float changeSpeed;
    public float changeHandling;
    public float changeAcceleration;
    public float changeCoolness;
}
