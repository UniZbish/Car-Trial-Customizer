using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Body", menuName = "Car/Car Parts/Body")]
public class CarBodies : ScriptableObject
{

    public string bodyName;
    public string description;

    public int changeSpeed;
    public int changeHandling;
    public int changeAcceleration;
    public int changeCoolness;

    public GameObject carModel;
}
