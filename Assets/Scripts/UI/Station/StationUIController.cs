using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Screen
{
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


    private StationController _station;

    [SerializeField] private StationScreenChannelSO stationScreenChannel;
    [SerializeField] private ContractChannelSO _contractChannel;

    void Start()
    {
        stationScreenChannel.ChangeScreenAction += ChangeScreen;
        _contractChannel.AssignedContractAction += HandleAssignedContract;
    }

    private void OnValidate()
    {
        ChangeScreen(display);
    }

    private void ChangeScreen(Screen to)
    {
        display = to;

        switch (display)
        {
            case Screen.None:
                {
                    gameObject.SetActive(false);
                    rootScreen.gameObject.SetActive(true);
                    contractScreen.gameObject.SetActive(false);
                    fuelScreen.gameObject.SetActive(false);
                    break;
                }
            case Screen.Root:
                {
                    gameObject.SetActive(true);
                    rootScreen.gameObject.SetActive(true);
                    contractScreen.gameObject.SetActive(false);
                    fuelScreen.gameObject.SetActive(false);
                    break;
                }
            case Screen.Contract:
                {
                    if (_station)
                    {
                        contractScreen.RenderContracts(_station.contracts);
                    }

                    gameObject.SetActive(true);
                    rootScreen.gameObject.SetActive(false);
                    contractScreen.gameObject.SetActive(true);
                    fuelScreen.gameObject.SetActive(false);
                    break;
                }
            case Screen.Fuel:
                {
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
        _station = s;
        ChangeScreen(Screen.Root);
    }

    public void ClearStation()
    {
        _station = null;
        ChangeScreen(Screen.None);
    }

    void HandleAssignedContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        // Re-render contract board
        contractScreen.RenderContracts(_station.contracts);
    }
}
