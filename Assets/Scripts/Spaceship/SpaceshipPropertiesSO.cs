using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spaceship/Properties")]
public class SpaceshipPropertiesSO : ScriptableObject
{
    public int credits = 0;
    public float fuel = 1000;

    public void Reset()
    {
        credits = 0;
        fuel = 1000;
    }
}
