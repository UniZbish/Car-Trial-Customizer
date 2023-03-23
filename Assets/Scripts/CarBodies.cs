using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Body", menuName = "Car/Car Parts/Body")]
public class CarBodies : ScriptableObject
{

    public string bodyName;
    public string description;

    public float changeSpeed;
    public float changeHandling;
    public float changeAcceleration;
    public float changeCoolness;

    public GameObject carModel;
}
