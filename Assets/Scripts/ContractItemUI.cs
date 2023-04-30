using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ContractItemUI : MonoBehaviour
{

    [SerializeField]
    ContractScriptableObject contract;

    [SerializeField]
    TMP_Text nameField;

    [SerializeField]
    TMP_Text destinationField;

    [SerializeField]
    TMP_Text paymentField;

    [SerializeField]
    TMP_Text deadlineField;

    public ContractChannelSO contractChannel = default;

    public void Awake()
    {
    }

    public void OnEnable()
    {
        if (contract) {
            RenderContract();
        }
    }

    public void HandleAcceptContract()
    {
        Debug.Log("Accept Contract");
        contractChannel.AcceptContract(contract);
    }

    public void SetContract(ContractScriptableObject newContract)
    {
        contract = newContract;
        RenderContract();
    }

    private void RenderContract()
    {
        Debug.Log("Render contract");
        nameField.text = contract.contactName;
        if (contract.destination) {
            destinationField.text = contract.destination.name;
        }
        paymentField.text = contract.payment.ToString();
        deadlineField.text = contract.deadline.ToString();
    }
}
