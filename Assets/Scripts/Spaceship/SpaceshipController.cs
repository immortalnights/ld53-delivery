using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State {
    Idle,
    Traveling,
    Docking,
    Docked,
}

enum Direction {
    None,
    Forwards,
    Backwards,
}

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private EngineScriptableObject engine;

    [SerializeField] private SpaceshipChannelSO channel;

    [SerializeField] private VoidEventChannelSO gameOverChannel;

    [SerializeField] private SpaceshipPropertiesSO properties;

    [SerializeField] private GameplayStatisticsSO gameplayStatistics;

    private Rigidbody body;

    private ContractScriptableObject activeContract;

    private State state = State.Idle;
    private Direction direction = Direction.None;

    // Current docking/docked station
    private StationController location;

    public int Speed => Mathf.FloorToInt(body.velocity.magnitude);

    void Start()
    {
        body = GetComponent<Rigidbody>();
        channel.AcceptContractAction += HandleAcceptContract;
        channel.DockAction += HandleDocked;

        properties.Reset();
        gameplayStatistics.Reset();

        StationController[] stations = FindObjectsOfType<StationController>();
        foreach(StationController station in stations) {
            if (station.name == "Station Alpha") {
                transform.LookAt(station.transform);
                break;
            }
        }
    }

    void Update()
    {
        switch (state) {
            case State.Idle:
            case State.Traveling: {
                if (Input.GetButton("Fire1")) {
                    state = State.Traveling;
                    direction = Direction.Forwards;
                } else if (Input.GetButton("Fire2")) {
                    state = State.Traveling;
                    direction = Direction.Backwards;
                } else {
                    direction = Direction.None;
                }
                break;
            }
        }
    }

    void FixedUpdate()
    {
        switch (state) {
            case State.Docking: {
                // Stop when almost stopped
                if (body.velocity.magnitude < 2) {
                    Debug.Log("Docked...");
                    state = State.Docked;
                    gameObject.transform.position = location.transform.position;
                    body.velocity = new Vector3(0,0,0);
                    body.drag = 0;
                    channel.Docked(location);
                }
                break;
            }
            case State.Traveling: {
                if (direction == Direction.Forwards) {
                    properties.fuel -= 0.25f;
                    body.velocity += transform.rotation * Vector3.forward * engine.thrust;
                } else if (direction == Direction.Backwards) {
                    properties.fuel -= 0.25f;
                    body.velocity += transform.rotation * Vector3.back * engine.thrust;
                }
                break;
            }
        }
    }
    void HandleDocked(StationController station)
    {
        if (activeContract != null) {
            if (activeContract.destination == station) {
                Debug.Log("Contract completed");
                // TODO Use Event
                gameplayStatistics.contractsCompleted += 1;
                properties.credits += activeContract.payment;
                activeContract = null;

                if (station.contracts.Count == 0) {
                    Debug.Log("Station has no contracts, game over");
                    gameOverChannel.RaiseEvent();
                }
            } else {
                Debug.Log("Incorrect station for contract");
            }
        } else {
            Debug.Log("No active contract");
        }
    }

    void HandleAcceptContract(ContractScriptableObject contract)
    {
        Debug.Log("Accepted Contract");
        activeContract = contract;
        state = State.Idle;
        location = null;
        transform.LookAt(activeContract.destination.gameObject.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        StationController station = other.gameObject.GetComponent<StationController>();
        if (location == null && station != null) {
            Debug.LogFormat("Docking at {0}", station.name);
            state = State.Docking;
            location = station;
            body.drag = body.velocity.magnitude / 4;

            float dockingSpeed = body.velocity.magnitude;
            if (dockingSpeed > 100f) {
                properties.credits -= 1000;
            } else if (dockingSpeed > 100f) {
                properties.credits -= 500;
            } else if (dockingSpeed > 50f) {
                properties.credits -= 250;
            } else if (dockingSpeed > 10f) {
                properties.credits -= 100;
            }
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("Left");
    }
}
