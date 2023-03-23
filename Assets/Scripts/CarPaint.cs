using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paint Job", menuName = "Car/Paint Job")]
public class CarPaint : ScriptableObject
{
    public string paintName;
    public float changeSpeed;
    public float changeHandling;
    public float changeAcceleration;
    public float changeCoolness;

    public Material material;
}
