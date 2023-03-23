using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Addon", menuName = "Car/Car Parts/Addon")]
public class CarAddOn : ScriptableObject
{
    public GameObject model;

    public int changeSpeed;
    public int changeHandling;
    public int changeAcceleration;
    public int changeCoolness;
}
