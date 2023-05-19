using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractUIController : MonoBehaviour
{

    [SerializeField] private GameObject _contractItemPrefab;

    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private ContractChannelSO _contractChannel;

    [SerializeField] private StationScreenChannelSO stationScreenChannel;

    // Start is called before the first frame update
    void Start()
    {
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

    public void RenderContracts(List<ContractSO> contracts)
    {
        Debug.LogFormat("Render {0} contracts", contracts.Count);

        ClearContracts();
        foreach (ContractSO contract in contracts)
        {
            GameObject obj = Instantiate(_contractItemPrefab, scrollViewContent);
            ContractItem ui = obj.GetComponent<ContractItem>();
            ui._contractChannel = _contractChannel;
            ui.GetComponent<ContractItem>().SetContract(contract);
        }
    }

    private void ClearContracts()
    {
        while (scrollViewContent.childCount > 0)
        {
            Object.DestroyImmediate(scrollViewContent.GetChild(0).gameObject);
        }
    }

    public void HandleClose()
    {
        stationScreenChannel.Invoke(StationScreen.Root);
    }
}
