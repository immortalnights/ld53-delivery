using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContractManager : MonoBehaviour
{
    [SerializeField] private ContractChannelSO _contractChannel;

    [SerializeField] private SpaceshipChannelSO _spaceshipChannel;

    [SerializeField] private NotificationChannelSO _notificationChannel;

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
            if (contract.dropOffLocation == station)
            {
                var deadline = contract.acceptedTime.AddHours(contract.deadline);
                var currentTime = _gameManager.Date;
                Debug.LogFormat("Accepted {0}; Current {1}; Deadline {2} ({3})",
                    contract.acceptedTime,
                    currentTime,
                    deadline,
                    contract.deadline
                );

                if (currentTime <= deadline)
                {
                    _gameManager.playerProperties.credits += contract.payment;
                    _gameManager.gameplayStatistics.contractsCompleted += 1;

                    _notificationChannel.Send(string.Format("Contract completed\nPayment {0}", contract.payment));
                    _contractChannel.CompleteContract(contract, spaceship, station);
                }
                else
                {
                    _notificationChannel.Send("Contract failed");
                    _contractChannel.FailContract(contract, spaceship);
                }

                spaceship.ClearContract();
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

    public void AcceptContract(ContractSO contract)
    {
        contract.acceptedTime = _gameManager.Date;

        Debug.LogFormat("Accepted at {0}; Deadline at {1}",
            contract.acceptedTime,
            contract.acceptedTime.AddHours(contract.deadline)
        );

        // Always assign to the default spaceship
        var spaceship = GameObject.FindFirstObjectByType<SpaceshipController>();
        if (spaceship.AssignContract(contract))
        {
            _contractChannel.AssignContract(contract, spaceship);
        }
    }
}
