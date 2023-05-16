using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private HudController _hudPanel;
    [SerializeField] private StationUIController _stationPanel;
    [SerializeField] private GameOverPanelController _gameOverPanel;

    [Header("Listening to")]
    [SerializeField] private SpaceshipChannelSO _spaceshipChannel;
    [SerializeField] private VoidEventChannelSO _gameOverEvent;

    // Start is called before the first frame update
    void Start()
    {
        _spaceshipChannel.DockAction += HandleSpaceshipDocked;
        _spaceshipChannel.UndockAction += HandleSpaceshipUndocked;
        _gameOverEvent.OnEventRaised += HandleGameOver;

        _hudPanel.gameObject.SetActive(true);
        _stationPanel.gameObject.SetActive(false);
        _gameOverPanel.gameObject.SetActive(false);
    }

    private void HandleSpaceshipDocked(SpaceshipController spaceship, StationController station)
    {
        if (station.contracts.Count == 0)
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
        else
        {
            _stationPanel.SetStation(station);
        }
    }

    private void HandleSpaceshipUndocked()
    {
        _stationPanel.ClearStation();
        _stationPanel.gameObject.SetActive(false);
        _hudPanel.gameObject.SetActive(true);
    }

    private void HandleGameOver()
    {
        gameObject.SetActive(true);
        _gameOverPanel.gameObject.SetActive(false);
    }
}
