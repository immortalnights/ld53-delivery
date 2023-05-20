using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIActiveContract : MonoBehaviour
{
    private ContractSO _contract;

    [SerializeField] TMP_Text _nameField;
    [SerializeField] TMP_Text _pickUpField;
    [SerializeField] TMP_Text _dropOffField;
    [SerializeField] TMP_Text _paymentField;
    [SerializeField] TMP_Text _deadlineField;

    void Start()
    {
    }

    void Update()
    {
        if (_contract)
        {
            RenderContractDeadline();
        }
    }

    public void SetContract(ContractSO contract)
    {
        _contract = contract;
        RenderContract();
    }

    public void ClearContract()
    {
        _contract = null;
        _nameField.text = "";
        _pickUpField.text = "";
        _dropOffField.text = "";
        _paymentField.text = "";
        _deadlineField.text = "";
    }

    void RenderContract()
    {
        _nameField.text = _contract.contractName;
        _pickUpField.text = _contract.pickUpLocation.name;
        _dropOffField.text = _contract.dropOffLocation.name;
        _paymentField.text = string.Format("{0} Credits", _contract.payment);
        RenderContractDeadline();
    }

    void RenderContractDeadline()
    {
        var gameManager = GameObject.FindFirstObjectByType<GameManager>();
        var hours = (_contract.acceptedTime.AddHours(_contract.deadline) - gameManager.Date).TotalHours;
        if (hours < 0)
        {
            _deadlineField.text = string.Format("Expired");
        }
        else
        {
            _deadlineField.text = string.Format("{0} Hours Remaining", hours);
        }
    }

}
