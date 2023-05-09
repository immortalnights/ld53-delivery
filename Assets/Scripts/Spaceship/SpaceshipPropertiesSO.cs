using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spaceship/Properties")]
public class SpaceshipPropertiesSO : ScriptableObject
{
  public int credits = 0;
  public float fuel = 0f;

  public float maximumFuel = 0f;

  public void Reset()
  {
    credits = 100000;
    fuel = 20;
    maximumFuel = 100f;
  }
}
