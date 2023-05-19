using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUIController : MonoBehaviour
{
    [SerializeField] private StationScreenChannelSO _stationScreenChannel;
    [SerializeField] private SpaceshipChannelSO _spaceshipChannel;
    [SerializeField] private SpaceshipPropertiesSO _spaceshipProperties;

    public void HandleBuyQuarter()
    {
        _spaceshipChannel.Refuel(Mathf.FloorToInt(_spaceshipProperties.maximumFuel * 0.25f));
    }
    public void HandleBuyHalf()
    {
        _spaceshipChannel.Refuel(Mathf.FloorToInt(_spaceshipProperties.maximumFuel * 0.5f));
    }
    public void HandleBuyMaximum()
    {
        _spaceshipChannel.Refuel(Mathf.FloorToInt(_spaceshipProperties.maximumFuel * 1f));
    }

    public void HandleClose()
    {
        _stationScreenChannel.Invoke(StationScreen.Root);
    }
}
