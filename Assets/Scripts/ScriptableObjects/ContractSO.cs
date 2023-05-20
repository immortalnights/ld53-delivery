using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Scriptable Objects/Contract")]
public class ContractSO : ScriptableObject
{
    public string contractName;
    public StationController pickUpLocation;
    public StationController dropOffLocation;
    public int payment;
    // Time to complete the contract, in hours
    public float deadline;

    public DateTime acceptedTime;

    public static ContractSO GenerateContract(StationController pickUp = null, StationController dropOff = null)
    {
        string[] contractNames = new string[] {
            "Personal Transport",
            "Passenger Transport",
            "Resource Delivery",
            "Mining Equipment Transport",
            "Electronics Delivery",
            "Military Hardware Delivery",
            "Confidential Cargo",
        };

        if (pickUp == null)
        {
            pickUp = StationController.GetRandomStation();
        }

        if (dropOff == null)
        {
            dropOff = StationController.GetRandomStation(pickUp);
        }

        ContractSO contract = ScriptableObject.CreateInstance<ContractSO>();
        contract.contractName = contractNames[UnityEngine.Random.Range(0, contractNames.Length)];
        contract.pickUpLocation = pickUp;
        contract.dropOffLocation = dropOff;
        contract.deadline = UnityEngine.Random.Range(8, 24);
        contract.payment = 1500 + Mathf.FloorToInt(contract.deadline) * 100;

        return contract;
    }
}
