using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    [SerializeField] private SpaceshipChannelSO channel;

    [SerializeField] private VoidEventChannelSO gameOverChannel;

    public List<ContractScriptableObject> contracts;

    void Start()
    {
        channel.AcceptContractAction += HandleAcceptContract;

        List<StationController> otherStations = new List<StationController>(FindObjectsOfType<StationController>());
        otherStations.Remove(this);

        const int contractCount = 0;
        for (int i = 0; i < contractCount; i++) {
            ContractScriptableObject contact = ContractScriptableObject.CreateInstance<ContractScriptableObject>();
            contact.destination = otherStations[Random.Range(0, otherStations.Count)];
            contact.deadline = Random.Range(3, 12);
            contact.payment = 1500 - Mathf.FloorToInt(contact.deadline) * 100;
            contracts.Add(contact);
        }
    }

    void Update()
    {
    }

    void HandleAcceptContract(ContractScriptableObject acceptedContract)
    {
        contracts.Remove(acceptedContract);
    }
}
