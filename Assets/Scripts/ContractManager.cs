using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContractManager : MonoBehaviour
{

    [SerializeField] private ContractChannelSO _contractChannel;

    [SerializeField] private SpaceshipChannelSO _spaceshipChannel;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _spaceshipChannel.DockAction += HandleSpaceshipDocked;
        _contractChannel.AcceptContractAction += AcceptContract;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleSpaceshipDocked(SpaceshipController spaceship, StationController station)
    {
        var contract = spaceship.activeContract;

        if (contract != null)
        {
            if (contract.destination == station)
            {
                var deadline = contract.acceptedTime.Date.AddHours(contract.deadline);
                var currentTime = _gameManager.Date.AddHours(contract.deadline);
                if (currentTime <= deadline)
                {
                    Debug.Log("Contract completed");
                    _contractChannel.CompleteContract(contract, spaceship, station);
                }
                else
                {
                    _contractChannel.FailContract(contract, spaceship);
                }
            }
            else
            {
                Debug.Log("Incorrect station for contract");
            }
        }
        else
        {
            Debug.Log("No active contract");
        }
    }

    public void AcceptContract(ContractScriptableObject contract)
    {
        contract.acceptedTime = _gameManager.Date;

        // Always assign to the default spaceship
        var spaceship = GameObject.FindFirstObjectByType<SpaceshipController>();
        if (spaceship.AssignContract(contract))
        {
            _contractChannel.AssignContract(contract, spaceship);
        }
    }

}
