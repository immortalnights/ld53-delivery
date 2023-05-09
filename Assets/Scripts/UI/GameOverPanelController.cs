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
  [SerializeField] SpaceshipPropertiesSO spaceshipProperties;
  [SerializeField] GameplayStatisticsSO gameplayStatistics;

  void Start()
  {
    creditsField.text = spaceshipProperties.credits.ToString();
    contractsField.text = gameplayStatistics.contractsCompleted.ToString();
    distanceField.text = gameplayStatistics.distanceTraveled.ToString();
    fuelField.text = gameplayStatistics.fuelConsumed.ToString();
  }

  public void HandleExitGameClick()
  {
    Debug.Log("Quit?");
    Application.Quit();
  }
}
