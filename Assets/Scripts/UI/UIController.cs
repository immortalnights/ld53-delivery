using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private HudController hud;
    [SerializeField] private ContactBoardController contactBoard;
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
        contactBoard.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    private void HandleSpaceshipDocked(StationController station)
    {
        if (station.contracts.Count == 0) {
            gameOverPanel.gameObject.SetActive(true);
        } else {
            contactBoard.gameObject.SetActive(true);
            contactBoard.RenderContacts(station.contracts);
        }
    }

    private void HandleAcceptContract(ContractScriptableObject contract)
    {
        contactBoard.gameObject.SetActive(false);
    }

    private void HandleGameOver()
    {
        gameObject.SetActive(true);
    }
}
