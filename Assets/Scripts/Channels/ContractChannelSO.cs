using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Contract Channel")]
public class ContractChannelSO : ScriptableObject
{
    public event UnityAction<ContractScriptableObject> AcceptContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> AssignedContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> CompleteContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> FailContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> CancelContractAction;

    public void AcceptContract(ContractScriptableObject contract)
    {
        AcceptContractAction.Invoke(contract);
    }

    public void CheckContract(ContractScriptableObject contract, SpaceshipController spaceship, StationController station)
    {
    }

    public void AssignContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        if (AssignedContractAction != null)
        {
            AssignedContractAction.Invoke(contract, spaceship);
        }
    }

    public void CompleteContract(ContractScriptableObject contract, SpaceshipController spaceship, StationController station)
    {
        if (CompleteContractAction != null)
        {
            CompleteContractAction.Invoke(contract, spaceship);
        }
    }

    public void FailContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        if (FailContractAction != null)
        {
            FailContractAction.Invoke(contract, spaceship);
        }
    }

    public void CancelContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        if (CancelContractAction != null)
        {
            CancelContractAction.Invoke(contract, spaceship);
        }
    }
}
