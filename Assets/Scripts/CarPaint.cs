using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paint Job", menuName = "Car/Paint Job")]
public class CarPaint : ScriptableObject
{
    public string paintName;
    public int changeSpeed;
    public int changeHandling;
    public int changeAcceleration;
    public int changeCoolness;

    public Material material;
}
