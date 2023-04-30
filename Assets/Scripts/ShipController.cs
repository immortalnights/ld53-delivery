using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public EngineScriptableObject engine;
    public Rigidbody body;

    public ContractScriptableObject activeContract;

    [SerializeField]
    private ContractChannelSO ContractChannel;

    bool isAccelerating= false;
    bool isBreaking = false;
    bool isWebbed = false;

    StationController location;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        ContractChannel.AcceptContractAction += HandleAcceptContract;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            isAccelerating = true;
            isBreaking = false;
        } else if (Input.GetButton("Fire2")) {
            isBreaking = true;
            isAccelerating = false;
        } else {
            isAccelerating = false;
            isBreaking = false;
        }
    }

    void FixedUpdate()
    {
        if (!isWebbed) {
            if (location == null) {
                if (isAccelerating) {
                    body.velocity += transform.rotation * Vector3.forward * engine.thrust;
                } else if (isBreaking) {
                    body.velocity += transform.rotation * Vector3.back * engine.thrust;
                }
            }
        } else {
            if (body.velocity.magnitude < 2) {
                Debug.Log("Full stop");
                body.velocity = new Vector3(0,0,0);
                isWebbed = false;
                body.drag = 0;
                // docked
                HandleDockingComplete();
            }
        }
    }

    void HandleAcceptContract(ContractScriptableObject contract)
    {
        Debug.Log("Accepted Contract");
        activeContract = contract;
        location = null;
        isAccelerating = false;
        isBreaking = false;
        isWebbed = true;
        transform.LookAt(activeContract.destination.gameObject.transform);
    }

    void HandleDockingComplete()
    {
        if (activeContract) {
            if (activeContract.destination == location) {

                // Allow pick up contract
                FindObjectOfType<UIController>().ToggleContactBoard(true, location);
            } else {
                Debug.Log("Station is incorrect for current contact");
            }
        } else {
            Debug.Log("No active contact");
            // Allow pick up contract
            FindObjectOfType<UIController>().ToggleContactBoard(true, location);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        StationController station = other.gameObject.GetComponent<StationController>();
        if (station != null) {
            Debug.Log(string.Format("Docking at {0}", station.name));
            isAccelerating = false;
            isBreaking = false;
            isWebbed = true;
            location = station;
            body.drag = body.velocity.magnitude / 4;
        }
    }

    void OnTriggerExit()
    {
        Debug.Log("Left");
    }
}
