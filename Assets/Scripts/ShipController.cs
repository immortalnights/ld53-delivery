using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public EngineScriptableObject engine;
    public Rigidbody rb;

    bool isAccelerating= false;
    bool isBreaking = false;
    bool isWebbed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
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
            if (isAccelerating) {
                rb.velocity += Vector3.right * engine.thrust;
            } else if (isBreaking) {
                rb.velocity += Vector3.left * engine.thrust;
            }
        } else {
            if (rb.velocity.magnitude < 2) {
                Debug.Log("Full stop");
                rb.velocity = new Vector3(0,0,0);
                isWebbed = false;
                rb.drag = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isWebbed = true;
        rb.drag = rb.velocity.magnitude / 4;
    }
}
