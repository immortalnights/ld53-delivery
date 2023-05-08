using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUIController : MonoBehaviour
{
    [SerializeField] private Transform fuelButton;
    [SerializeField] private Transform contractButton;

    [SerializeField] private StationScreenChannelSO stationScreenChannel;

    public void OnClickContract()
    {
        stationScreenChannel.Invoke(Screen.Contract);
    }

    public void OnClickFuel()
    {
        stationScreenChannel.Invoke(Screen.Fuel);
    }
}
