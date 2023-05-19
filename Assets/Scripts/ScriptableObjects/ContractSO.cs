using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Contract")]
public class ContractSO : ScriptableObject
{
    public string contractName;
    public StationController destination;
    public int payment;
    // Time to complete the contract
    public float deadline;

    public DateTime acceptedTime;
}
