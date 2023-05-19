using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Idle,
    Traveling,
    Docking,
    Docked,
}

enum Direction
{
    None,
    Forwards,
    Backwards,
}

public class SpaceshipController : MonoBehaviour
{

    [SerializeField] private EngineScriptableObject engine;
    [SerializeField] private SpaceshipPropertiesSO properties;

    [Header("Listening to...")]
    [SerializeField] private SpaceshipChannelSO channel;
    [SerializeField] private ContractChannelSO _contractChannel;

    [SerializeField] private VoidEventChannelSO gameOverChannel;

    private Rigidbody body;

    public ContractSO activeContract
    {
        get;
        private set;
    }

    private State state = State.Idle;
    private Direction direction = Direction.None;

    // Current docking/docked station
    private StationController location;

    public int Speed => Mathf.FloorToInt(body.velocity.magnitude);

    void Start()
    {
        body = GetComponent<Rigidbody>();
        channel.UndockAction += HandleUndocked;
        channel.RefuelAction += HandleRefuel;

        properties.Reset();

        StationController[] stations = FindObjectsOfType<StationController>();
        foreach (StationController station in stations)
        {
            if (station.name == "Station Alpha")
            {
                transform.LookAt(station.transform);
                break;
            }
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
            case State.Traveling:
                {
                    if (Input.GetButton("Fire1"))
                    {
                        state = State.Traveling;
                        direction = Direction.Forwards;
                    }
                    else if (Input.GetButton("Fire2"))
                    {
                        state = State.Traveling;
                        direction = Direction.Backwards;
                    }
                    else
                    {
                        direction = Direction.None;
                    }
                    break;
                }
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.Docking:
                {
                    // Stop when almost stopped
                    if (body.velocity.magnitude < 2)
                    {
                        Debug.Log("Docked...");
                        state = State.Docked;
                        gameObject.transform.position = location.transform.position;
                        body.velocity = new Vector3(0, 0, 0);
                        body.drag = 0;
                        channel.Docked(this, location);
                    }
                    break;
                }
            case State.Traveling:
                {
                    if (properties.fuel > 0)
                    {
                        if (direction == Direction.Forwards)
                        {
                            properties.fuel -= 0.25f;
                            body.velocity += transform.rotation * Vector3.forward * engine.thrust;
                        }
                        else if (direction == Direction.Backwards)
                        {
                            properties.fuel -= 0.25f;
                            body.velocity += transform.rotation * Vector3.back * engine.thrust;
                        }
                    }
                    else
                    {
                        // Display emergency fuel dialog
                        // If the player cannot afford it, game over.
                        gameOverChannel.RaiseEvent(/* OutOfFuel */);
                    }
                    break;
                }
        }
    }


    void HandleUndocked()
    {
        state = State.Idle;
    }

    public bool AssignContract(ContractSO contract)
    {
        var assigned = false;
        if (activeContract == null)
        {
            Debug.Log("Spaceship Assigned Contract");
            activeContract = contract;
            location = null;
            transform.LookAt(activeContract.destination.gameObject.transform);
            assigned = true;
        }
        else
        {
            Debug.LogWarning("Failed to assign contract, contract in progress");
        }

        return assigned;
    }

    public void CompleteContract(ContractSO contract)
    {
        Debug.AssertFormat(activeContract && activeContract == contract, "Attempted to complete invalid contract");
        activeContract = null;
        Debug.Log("Contract completed");
    }

    public void FailContract(ContractChannelSO contract)
    {
        Debug.AssertFormat(activeContract && activeContract == contract, "Attempted to fail invalid contract");
        activeContract = null;
        Debug.Log("Contract failed");
    }


    void HandleRefuel(int amount)
    {
        properties.fuel += Mathf.Min(properties.fuel + amount, properties.maximumFuel);

        // const int fuelUnitCost = 1;

        // Debug.LogFormat("refuelRequested {0}", amount);
        // float refuelRequired = Mathf.Min(properties.maximumFuel * amount, properties.maximumFuel - properties.fuel);
        // Debug.LogFormat("refuelRequired {0}", refuelRequired);
        // float canAfford = Mathf.Floor(properties.credits / fuelUnitCost);
        // Debug.LogFormat("canAfford {0}", canAfford);
        // float refuelAmount = Mathf.Min(canAfford, refuelRequired);
        // Debug.LogFormat("refuelAmount {0}", refuelAmount);

        // Debug.LogFormat("current fuel {0}", properties.fuel);
        // properties.credits -= Mathf.CeilToInt(refuelAmount * fuelUnitCost);
        // properties.fuel += refuelAmount;
        // Debug.LogFormat("fuel {0}", properties.fuel);
        // TODO some UI notification
    }

    void OnTriggerEnter(Collider other)
    {
        StationController station = other.gameObject.GetComponent<StationController>();
        if (location == null && station != null)
        {
            Debug.LogFormat("Docking at {0}", station.name);
            state = State.Docking;
            location = station;
            body.drag = body.velocity.magnitude / 4;

            // float dockingSpeed = body.velocity.magnitude;
            // if (dockingSpeed > 100f)
            // {
            //     properties.credits -= 1000;
            // }
            // else if (dockingSpeed > 100f)
            // {
            //     properties.credits -= 500;
            // }
            // else if (dockingSpeed > 50f)
            // {
            //     properties.credits -= 250;
            // }
            // else if (dockingSpeed > 10f)
            // {
            //     properties.credits -= 100;
            // }
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("Left");
    }
}
