using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactBoardController : MonoBehaviour
{
    [SerializeField] private GameObject contactItemPrefab;

    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private SpaceshipChannelSO spaceshipChannel = default;

    // Start is called before the first frame update
    void Start()
    {
        // spaceshipChannel.DockAction += HandleSpaceshipDocked;
        // spaceshipChannel.AcceptContractAction += HandleAcceptContract;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        Debug.Log("Clear contracts");
        ClearContracts();
    }

    public void RenderContacts(List<ContractScriptableObject> contracts)
    {
        Debug.LogFormat("Render {0} contracts", contracts.Count);

        foreach(ContractScriptableObject contract in contracts) {
            Debug.Log("Create contract ui");
            GameObject obj = Instantiate(contactItemPrefab, scrollViewContent);
            ContractItemUI ui = obj.GetComponent<ContractItemUI>();
            ui.spaceshipChannel = spaceshipChannel;
            ui.GetComponent<ContractItemUI>().SetContract(contract);
        }
    }

    private void ClearContracts()
    {
        while (scrollViewContent.childCount > 0) {
            Object.DestroyImmediate(scrollViewContent.GetChild(0).gameObject);
        }
    }

    // void HandleSpaceshipDocked(StationController station)
    // {
    //     Debug.Log("UI handle docked");
    //     // gameObject.SetActive(true);
    //     RenderContacts(station.contracts);
    // }

    // void HandleAcceptContract(ContractScriptableObject contract)
    // {
    //     Debug.Log("UI accept contract");
    //     // gameObject.SetActive(false);
    //     ClearContracts();
    // }

    public void HandleClose()
    {
        Debug.Log("UI handle close");
        gameObject.SetActive(false);
        ClearContracts();
    }
}
