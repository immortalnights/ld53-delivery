using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Contract")]
public class ContractScriptableObject : ScriptableObject
{
  public string contactName;
  public StationController destination;
  public int payment;
  // Time to complete the contact
  public float deadline;
}
