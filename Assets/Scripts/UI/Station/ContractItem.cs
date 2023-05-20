using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ContractItem : MonoBehaviour
{
    public ContractSO contract
    {
        get;
        private set;
    }

    [SerializeField] private TMP_Text nameField;

    [SerializeField] private TMP_Text destinationField;

    [SerializeField] private TMP_Text paymentField;

    [SerializeField] private TMP_Text deadlineField;

    // Set when instantiated
    [SerializeField] public ContractChannelSO _contractChannel;

    public void Awake()
    {
    }

    public void OnEnable()
    {
        if (contract)
        {
            RenderContract();
        }
    }

    public void HandleAcceptContract()
    {
        Debug.Log("Accept Contract");
        _contractChannel.AcceptContract(contract);
    }

    public void SetContract(ContractSO newContract)
    {
        contract = newContract;
        RenderContract();
    }

    private void RenderContract()
    {
        nameField.text = contract.contractName;
        if (contract.dropOffLocation)
        {
            destinationField.text = contract.dropOffLocation.name;
        }
        paymentField.text = contract.payment.ToString();
        deadlineField.text = contract.deadline.ToString() + " Days";
    }
}
