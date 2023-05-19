using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Contract Channel")]
public class ContractChannelSO : ScriptableObject
{
    public event UnityAction<ContractSO> AcceptContractAction;
    public event UnityAction<ContractSO, SpaceshipController> AssignedContractAction;
    public event UnityAction<ContractSO, SpaceshipController> CompleteContractAction;
    public event UnityAction<ContractSO, SpaceshipController> FailContractAction;
    public event UnityAction<ContractSO, SpaceshipController> CancelContractAction;

    public void AcceptContract(ContractSO contract)
    {
        AcceptContractAction.Invoke(contract);
    }

    public void CheckContract(ContractSO contract, SpaceshipController spaceship, StationController station)
    {
    }

    public void AssignContract(ContractSO contract, SpaceshipController spaceship)
    {
        if (AssignedContractAction != null)
        {
            AssignedContractAction.Invoke(contract, spaceship);
        }
    }

    public void CompleteContract(ContractSO contract, SpaceshipController spaceship, StationController station)
    {
        if (CompleteContractAction != null)
        {
            CompleteContractAction.Invoke(contract, spaceship);
        }
    }

    public void FailContract(ContractSO contract, SpaceshipController spaceship)
    {
        if (FailContractAction != null)
        {
            FailContractAction.Invoke(contract, spaceship);
        }
    }

    public void CancelContract(ContractSO contract, SpaceshipController spaceship)
    {
        if (CancelContractAction != null)
        {
            CancelContractAction.Invoke(contract, spaceship);
        }
    }
}
