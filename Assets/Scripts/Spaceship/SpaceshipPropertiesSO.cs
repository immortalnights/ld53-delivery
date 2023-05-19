using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spaceship/Properties")]
public class SpaceshipPropertiesSO : ScriptableObject
{
    public float fuel = 0f;
    public float maximumFuel = 0f;

    public void Reset()
    {
        fuel = 20;
        maximumFuel = 100f;
    }
}
