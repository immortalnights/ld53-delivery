using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] TMP_Text creditsField;
    [SerializeField] TMP_Text contractsField;
    [SerializeField] TMP_Text distanceField;
    [SerializeField] TMP_Text fuelField;
    [SerializeField] PlayerPropertiesSO _playerProperties;
    [SerializeField] GameplayStatisticsSO _gameplayStatistics;
    [SerializeField] SpaceshipPropertiesSO _spaceshipProperties;

    void Start()
    {
        creditsField.text = _playerProperties.credits.ToString();
        contractsField.text = _gameplayStatistics.contractsCompleted.ToString();
        distanceField.text = _gameplayStatistics.distanceTraveled.ToString();
        fuelField.text = _gameplayStatistics.fuelConsumed.ToString();
    }

    public void HandleExitGameClick()
    {
        Debug.Log("Quit?");
        Application.Quit();
    }
}
