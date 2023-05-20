using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActiveContractsContainer : MonoBehaviour
{
    [SerializeField] ContractChannelSO _contractChannel;
    [SerializeField] GameObject _panelObject;

    void Start()
    {
        _contractChannel.AssignedContractAction += HandleAssignedContract;
        _contractChannel.CompleteContractAction += HandleContractCleared;
        _contractChannel.FailContractAction += HandleContractCleared;
        _contractChannel.CancelContractAction += HandleContractCleared;
    }

    void Update()
    {
    }

    void HandleAssignedContract(ContractSO contract, SpaceshipController spaceship)
    {
        _panelObject.SetActive(true);
        _panelObject.GetComponent<UIActiveContract>().SetContract(contract);
    }

    void HandleContractCleared(ContractSO contract, SpaceshipController spaceship)
    {
        _panelObject.GetComponent<UIActiveContract>().ClearContract();
        _panelObject.SetActive(false);
    }
}
