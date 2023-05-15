using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUIController : MonoBehaviour
{
    [SerializeField] private StationScreenChannelSO _stationScreenChannel;
    [SerializeField] private SpaceshipChannelSO _spaceshipChannel = default;


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
