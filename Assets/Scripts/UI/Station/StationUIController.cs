using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Screen {
    None,
    Root,
    Contract,
    Fuel,
}

public class StationUIController : MonoBehaviour
{
    [SerializeField] private Screen display = Screen.None;

    [SerializeField] private RootUIController rootScreen;
    [SerializeField] private FuelUIController fuelScreen;
    [SerializeField] private ContractUIController contractScreen;

    private StationController station;

    [SerializeField] private StationScreenChannelSO stationScreenChannel;

    void Start()
    {
        stationScreenChannel.ChangeScreenAction += ChangeScreen;
    }

    private void OnValidate()
    {
        ChangeScreen(display);
    }

    private void ChangeScreen(Screen to)
    {
        display = to;

        switch (display) {
            case Screen.None: {
                gameObject.SetActive(false);
                rootScreen.gameObject.SetActive(true);
                contractScreen.gameObject.SetActive(false);
                fuelScreen.gameObject.SetActive(false);
                break;
            }
            case Screen.Root: {
                gameObject.SetActive(true);
                rootScreen.gameObject.SetActive(true);
                contractScreen.gameObject.SetActive(false);
                fuelScreen.gameObject.SetActive(false);
                break;
            }
            case Screen.Contract: {
                gameObject.SetActive(true);
                rootScreen.gameObject.SetActive(false);
                contractScreen.gameObject.SetActive(true);
                fuelScreen.gameObject.SetActive(false);
                break;
            }
            case Screen.Fuel: {
                gameObject.SetActive(true);
                rootScreen.gameObject.SetActive(false);
                contractScreen.gameObject.SetActive(false);
                fuelScreen.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void SetStation(StationController s)
    {
        station = s;
        ChangeScreen(Screen.Root);
    }

    public void ClearStation()
    {
        station = null;
        ChangeScreen(Screen.None);
    }
}
