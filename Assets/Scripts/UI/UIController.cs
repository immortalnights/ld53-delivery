using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private HudController hud;
    [SerializeField] private StationUIController stationPanel;
    [SerializeField] private GameOverPanelController gameOverPanel;

    [Header("Listening to")]
    [SerializeField] private SpaceshipChannelSO _spaceshipChannel = default;
    [SerializeField] private VoidEventChannelSO gameOverChannel = default;

    // Start is called before the first frame update
    void Start()
    {
        _spaceshipChannel.DockAction += HandleSpaceshipDocked;
        _spaceshipChannel.UndockAction += HandleSpaceshipUndocked;
        gameOverChannel.OnEventRaised += HandleGameOver;

        hud.gameObject.SetActive(true);
        stationPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    private void HandleSpaceshipDocked(StationController station)
    {
        if (station.contracts.Count == 0)
        {
            gameOverPanel.gameObject.SetActive(true);
        }
        else
        {
            stationPanel.SetStation(station);
        }
    }

    private void HandleSpaceshipUndocked()
    {
        stationPanel.ClearStation();
        stationPanel.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
    }

    private void HandleGameOver()
    {
        gameObject.SetActive(true);
    }
}
