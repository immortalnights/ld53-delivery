using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StationScreen
{
    None,
    Root,
    Contract,
    Fuel,
}

public class StationUIController : MonoBehaviour
{
    [SerializeField] private StationScreen display = StationScreen.None;

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

    private void ChangeScreen(StationScreen to)
    {
        display = to;

        switch (display)
        {
            case StationScreen.None:
                {
                    gameObject.SetActive(false);
                    rootScreen.gameObject.SetActive(true);
                    contractScreen.gameObject.SetActive(false);
                    fuelScreen.gameObject.SetActive(false);
                    break;
                }
            case StationScreen.Root:
                {
                    gameObject.SetActive(true);
                    rootScreen.gameObject.SetActive(true);
                    contractScreen.gameObject.SetActive(false);
                    fuelScreen.gameObject.SetActive(false);
                    break;
                }
            case StationScreen.Contract:
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
            case StationScreen.Fuel:
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
        ChangeScreen(StationScreen.Root);
    }

    public void ClearStation()
    {
        _station = null;
        ChangeScreen(StationScreen.None);
    }

    void HandleAssignedContract(ContractScriptableObject contract, SpaceshipController spaceship)
    {
        // Re-render contract board
        contractScreen.RenderContracts(_station.contracts);
    }
}
