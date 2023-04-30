using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
  [SerializeField] private TMP_Text creditsValue;
  [SerializeField] private TMP_Text fuelValue;
  [SerializeField] private TMP_Text speedValue;

  private SpaceshipController spaceship;
  [SerializeField] private SpaceshipChannelSO spaceshipChannel = default;
  [SerializeField] private SpaceshipPropertiesSO spaceshipProperties;

  void Start()
  {
    spaceshipChannel.DockAction += HandleDocked;
    spaceshipChannel.AcceptContractAction += HandleAcceptContract;
    spaceship = FindFirstObjectByType<SpaceshipController>();
    Debug.Assert(spaceship != null, "Failed to find Spaceship(Controller)");
  }

  void Update()
  {
    speedValue.text = spaceship.Speed.ToString();

    if (spaceship.Speed == 0) {
      speedValue.color = Color.gray;
    } else if (spaceship.Speed < 12) {
      speedValue.color = Color.green;
    } else {
      speedValue.color = Color.red;
    }

    creditsValue.text = spaceshipProperties.credits.ToString();
    fuelValue.text = Mathf.FloorToInt(spaceshipProperties.fuel).ToString();
  }

  private void HandleDocked(StationController station)
  {
    gameObject.SetActive(false);
  }

  private void HandleAcceptContract(ContractScriptableObject contract)
  {
    gameObject.SetActive(true);
  }
}