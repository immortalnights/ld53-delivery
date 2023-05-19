using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] private ContractChannelSO _contractChannel;

    public List<ContractSO> contracts
    {
        get;
        private set;
    }

    void Start()
    {
        contracts = new List<ContractSO>();
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
            ContractSO contract = ContractSO.CreateInstance<ContractSO>();
            contract.contractName = contractNames[Random.Range(0, contractNames.Length)];
            contract.destination = otherStations[Random.Range(0, otherStations.Count)];
            contract.deadline = Random.Range(8, 24);
            contract.payment = 1500 + Mathf.FloorToInt(contract.deadline) * 100;
            contracts.Add(contract);
        }
    }

    void Update()
    {
    }

    void HandleAssignedContract(ContractSO acceptedContract, SpaceshipController spaceship)
    {
        contracts.Remove(acceptedContract);
    }
}
