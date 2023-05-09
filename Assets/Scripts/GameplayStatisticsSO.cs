using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GameplayStatistics")]
public class GameplayStatisticsSO : ScriptableObject
{
  public int contractsCompleted = 0;
  public float distanceTraveled = 0f;

  public float fuelConsumed = 0f;

  public void Reset()
  {
    contractsCompleted = 0;
    distanceTraveled = 0f;
    fuelConsumed = 0f;
  }
}
