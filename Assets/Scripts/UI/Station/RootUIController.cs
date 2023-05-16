using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUIController : MonoBehaviour
{
    [SerializeField] private StationScreenChannelSO _stationScreenChannel;
    [SerializeField] private SpaceshipChannelSO _spaceshipChannel;

    [SerializeField] private Transform _undockButton;

    [SerializeField] private ContractChannelSO _contractChannel;

    void Start()
    {
        // _undockButton.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Debug.Log("enable?");
    }

    public void OnClickContract()
    {
        _stationScreenChannel.Invoke(Screen.Contract);
    }

    public void OnClickFuel()
    {
        _stationScreenChannel.Invoke(Screen.Fuel);
    }

    public void OnClickUndock()
    {
        _spaceshipChannel.Undocked();
    }
}
