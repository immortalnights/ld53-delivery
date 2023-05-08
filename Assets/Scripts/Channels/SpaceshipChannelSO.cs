using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Spaceship Channel")]
public class SpaceshipChannelSO : ScriptableObject
{
    public event UnityAction<StationController> DockAction;
    public event UnityAction<ContractScriptableObject> AcceptContractAction;

    public event UnityAction<float> RefuelAction;

    // Invoked when the Spaceship (player) docks at a station
    public void Docked(StationController station)
    {
        Debug.Log("Docked");
        DockAction.Invoke(station);
    }

    // Invoked when the Spaceship (player) accepts a contract
    public void AcceptContract(ContractScriptableObject contract)
    {
        AcceptContractAction.Invoke(contract);
    }

    public void Refuel(float amount)
    {
        RefuelAction.Invoke(amount);
    }
}
