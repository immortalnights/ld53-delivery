using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelUIController : MonoBehaviour
{
    [SerializeField] private StationScreenChannelSO stationScreenChannel;
    [SerializeField] private SpaceshipChannelSO spaceshipChannel;

    public void HandleBuyQuarter()
    {
        spaceshipChannel.Refuel(0.25f);
    }
    public void HandleBuyHalf()
    {
        spaceshipChannel.Refuel(0.5f);
    }
    public void HandleBuyMaximum()
    {
        spaceshipChannel.Refuel(1f);
    }

    public void HandleClose()
    {
        stationScreenChannel.Invoke(Screen.Root);
    }
}
