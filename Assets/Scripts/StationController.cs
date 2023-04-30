using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    public List<ContractScriptableObject> contracts;

    // Start is called before the first frame update
    void Start()
    {
        List<StationController> otherStations = new List<StationController>(FindObjectsOfType<StationController>());
        otherStations.Remove(this);

        for (int i = 0; i < 5; i++) {
            ContractScriptableObject contact = ContractScriptableObject.CreateInstance<ContractScriptableObject>();
            contact.destination = otherStations[Random.Range(0, otherStations.Count)];
            contact.payment = 1000;
            contact.deadline = 10;
            contracts.Add(contact);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
