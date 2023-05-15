using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContractManager : MonoBehaviour
{

    [SerializeField] private ContractChannelSO _contractChannel = default;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        _contractChannel.AcceptContractAction += AcceptContract;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcceptContract(ContractScriptableObject contract)
    {
        contract.acceptedTime = _gameManager.Date;

        // Always assign to the default spaceship
        var spaceship = GameObject.FindFirstObjectByType<SpaceshipController>();
        _contractChannel.AssignContract(contract, spaceship);
    }
}
