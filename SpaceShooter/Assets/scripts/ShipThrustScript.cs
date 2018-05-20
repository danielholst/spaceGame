using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the thrust of the ship
public class ShipThrustScript : MonoBehaviour {

    public Rigidbody body;
    private float thrustForce;
    private float shipSlowDown;

    // Use this for initialization
    void Start () {
        thrustForce = 10.0f;
        shipSlowDown = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        ShipThrust();
    }

    // Accelerates the ship forward with the W key.
    // If W is not pressed and the ship is moving it will deaccelerate;
    private void ShipThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(body.transform.forward * thrustForce);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            body.velocity = body.velocity - shipSlowDown * body.velocity;
        }
    }
}