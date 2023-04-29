using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public EngineScriptableObject engine;
    public Rigidbody rb;

    bool isAccelerating= false;
    bool isBreaking = false;
    float logTimer = 0f;

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
        if (isAccelerating) {
            rb.velocity += Vector3.right * engine.thrust;
        } else if (isBreaking) {
            rb.velocity += Vector3.left * engine.thrust;
        }

        if (isAccelerating || isBreaking) {
            logTimer = logTimer + Time.fixedDeltaTime;
            if (logTimer > 10.0f) {
                Debug.Log(gameObject.transform.position.y + " : " + logTimer);
                logTimer = 0.0f;
            }
        }
    }
}
