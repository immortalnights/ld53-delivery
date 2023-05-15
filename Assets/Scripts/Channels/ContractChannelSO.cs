using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Contact Channel")]
public class ContractChannelSO : ScriptableObject
{
    public event UnityAction<ContractScriptableObject> AcceptContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> AssignContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> CompleteContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> FailContractAction;
    public event UnityAction<ContractScriptableObject, SpaceshipController> CancelContractAction;

    public void AcceptContract(ContractScriptableObject contract)
    {
        AcceptContractAction.Invoke(contract);
    }

    public void AssignContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        AssignContractAction.Invoke(contract, spaceship);
    }

    public void CompleteContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        CompleteContractAction.Invoke(contract, spaceship);
    }

    public void FailContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        FailContractAction.Invoke(contract, spaceship);
    }

    public void CancelContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        CancelContractAction.Invoke(contract, spaceship);
    }
}
