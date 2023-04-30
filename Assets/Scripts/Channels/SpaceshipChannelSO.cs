using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Channels/SpaceshipChannel")]
public class SpaceshipChannelSO : ScriptableObject
{
    public event UnityAction<StationController> DockAction;
    public event UnityAction<ContractScriptableObject> AcceptContractAction;

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
}
