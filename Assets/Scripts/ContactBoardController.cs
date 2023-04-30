using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactBoardController : MonoBehaviour
{
    [SerializeField]
    public GameObject contactItemPrefab;

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private ContractChannelSO contractChannel = default;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RenderContacts(List<ContractScriptableObject> contracts)
    {
        Debug.Log(string.Format("Render {0} contracts", contracts.Count));

        foreach(ContractScriptableObject contract in contracts) {
            GameObject obj = Instantiate(contactItemPrefab, scrollViewContent);
            ContractItemUI ui = obj.GetComponent<ContractItemUI>();
            ui.contractChannel = contractChannel;
            ui.GetComponent<ContractItemUI>().SetContract(contract);
        }
    }

    void HandleAcceptedContract(ContractScriptableObject contract)
    {
        gameObject.SetActive(false);
    }

    public void HandleClose()
    {
        gameObject.SetActive(false);
    }
}
