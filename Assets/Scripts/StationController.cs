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

    string[] contractNames = new string[] {
            "Personal Transport",
            "Passenger Transport",
            "Resource Delivery",
            "Mining Equipment Transport",
            "Electronics Delivery",
            "Military Hardware Delivery",
            "Confidential Cargo",
        };

    const int contractCount = 5;
    for (int i = 0; i < contractCount; i++)
    {
      ContractScriptableObject contact = ContractScriptableObject.CreateInstance<ContractScriptableObject>();
      contact.contactName = contractNames[Random.Range(0, contractNames.Length)];
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
