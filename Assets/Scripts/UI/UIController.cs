using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private HudController hud;
    [SerializeField] private StationUIController stationPanel;
    [SerializeField] private GameOverPanelController gameOverPanel;

	[Header("Listening to")]
    [SerializeField] private SpaceshipChannelSO spaceshipChannel = default;
    [SerializeField] private VoidEventChannelSO gameOverChannel = default;

    // Start is called before the first frame update
    void Start()
    {
        spaceshipChannel.DockAction += HandleSpaceshipDocked;
        spaceshipChannel.AcceptContractAction += HandleAcceptContract;
        gameOverChannel.OnEventRaised += HandleGameOver;

        hud.gameObject.SetActive(true);
        stationPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    private void HandleSpaceshipDocked(StationController station)
    {
        if (station.contracts.Count == 0) {
            gameOverPanel.gameObject.SetActive(true);
        } else {
            stationPanel.SetStation(station);
        }
    }

    private void HandleAcceptContract(ContractScriptableObject contract)
    {
        stationPanel.ClearStation();
    }

    private void HandleGameOver()
    {
        gameObject.SetActive(true);
    }
}
