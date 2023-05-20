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

        const int contractCount = 5;
        for (int i = 0; i < contractCount; i++)
        {
            contracts.Add(ContractSO.GenerateContract(this));
        }
    }

    void Update()
    {
    }

    public static StationController GetRandomStation(StationController exclude = null)
    {
        List<StationController> otherStations = new List<StationController>(FindObjectsOfType<StationController>());
        if (exclude != null)
        {
            otherStations.Remove(exclude);
        }

        return otherStations[Random.Range(0, otherStations.Count)];
    }

    void HandleAssignedContract(ContractSO acceptedContract, SpaceshipController spaceship)
    {
        contracts.Remove(acceptedContract);
    }
}
