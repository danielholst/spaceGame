using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

// Script to handle the thrust of the ship
public class ShipThrustScript : NetworkBehaviour {

    private Rigidbody body;
    private float thrustForce;
    private float shipSlowDown;
    private int shipBoost;

    // Use this for initialization
    void Start () {
        thrustForce = 10.0f;
        shipSlowDown = 0.1f;
        shipBoost = 1;
        body = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        ShipBoost();
        ShipThrust();
    }

    // Add extra force if boost is active
    // Boost ship with shift key
    private void ShipBoost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shipBoost = 3;
            Debug.Log("Boost!");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shipBoost = 1;
            Debug.Log("noooo Boost");
        }
    }

    // Accelerates the ship forward with the W key.
    // If W is not pressed and the ship is moving it will deaccelerate;
    private void ShipThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(body.transform.forward * thrustForce * shipBoost);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            body.velocity = body.velocity - shipSlowDown * body.velocity;
        }
    }
}