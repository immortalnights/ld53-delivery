using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/ContractChannel")]
public class ContractChannelSO : ScriptableObject
{
  public event UnityAction<ContractScriptableObject> AcceptContractAction;

  public void AcceptContract(ContractScriptableObject contract)
  {
    AcceptContractAction.Invoke(contract);
  }
}
