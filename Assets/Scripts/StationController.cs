using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] private ContractChannelSO _contractChannel;

    public List<ContractScriptableObject> contracts
    {
        get;
        private set;
    }

    void Start()
    {
        contracts = new List<ContractScriptableObject>();
        _contractChannel.AssignedContractAction += HandleAssignedContract;

        List<StationController> otherStations = new List<StationController>(FindObjectsOfType<StationController>());
        otherStations.Remove(this);

        string[] contractNames = new string[] {
            "Personal Transport",
            "Passenger Transport",
            "Resource Delivery",
            "Mining Equipment Transport",
            "Electronics Delivery",
            "Military Hardware Delivery",
            "Confidential Cargo",
        };

        const int contractCount = 5;
        for (int i = 0; i < contractCount; i++)
        {
            ContractScriptableObject contract = ContractScriptableObject.CreateInstance<ContractScriptableObject>();
            contract.contractName = contractNames[Random.Range(0, contractNames.Length)];
            contract.destination = otherStations[Random.Range(0, otherStations.Count)];
            contract.deadline = Random.Range(3, 12);
            contract.payment = 1500 - Mathf.FloorToInt(contract.deadline) * 100;
            contracts.Add(contract);
        }
    }

    void Update()
    {
    }

    void HandleAssignedContract(ContractScriptableObject acceptedContract, SpaceshipController spaceship)
    {
        contracts.Remove(acceptedContract);
    }
}
