using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ContractItemUI : MonoBehaviour
{
    [SerializeField] private ContractScriptableObject contract;

    [SerializeField] private TMP_Text nameField;

    [SerializeField] private TMP_Text destinationField;

    [SerializeField] private TMP_Text paymentField;

    [SerializeField] private TMP_Text deadlineField;

    // Set when instantiated
    public SpaceshipChannelSO spaceshipChannel = default;

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
        spaceshipChannel.AcceptContract(contract);
    }

    public void SetContract(ContractScriptableObject newContract)
    {
        contract = newContract;
        RenderContract();
    }

    private void RenderContract()
    {
        nameField.text = contract.contactName;
        if (contract.destination) {
            destinationField.text = contract.destination.name;
        }
        paymentField.text = contract.payment.ToString();
        deadlineField.text = contract.deadline.ToString();
    }
}
