using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System;

// Script to handle the thrust of the ship
public class ShipThrustScript : NetworkBehaviour {

    private Rigidbody body;
    private float thrustForce;
    private float shipSlowDown;
    private int shipBoost;
    private float shipSpeed;
    public Light mainLight;
    public Light leftLight;
    public Light rightLight;
    private float lightIntensityFactor;
    private readonly int maxIntensity = 50;

    // Use this for initialization
    void Start () {
        thrustForce = 0.5f;
        shipSlowDown = 0.3f;
        shipBoost = 1;
        shipSpeed = 0;
        body = GetComponent<Rigidbody>();
        lightIntensityFactor = 1f;
    }
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        ShipBoost();
        ShipThrust();
        HandleShipLights();
    }

    // TODO, at the moment shift is used for normal thrust!
    // maybe the boost will be applied right away when picked up and the last for a time 
    // without any specific user input.

    // Add extra force if boost is active
    // Boost ship with shift key
    private void ShipBoost()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shipBoost = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shipBoost = 1;
        }
    }

    // Accelerates the ship forward with the Shift key.
    // If Shift is not pressed and the ship is moving it will deaccelerate;
    private void ShipThrust()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (lightIntensityFactor < maxIntensity)
            lightIntensityFactor += 0.3f;
            shipSpeed += thrustForce * shipBoost;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && shipSpeed > 0.0f)
        {
            if (lightIntensityFactor > 3)
                lightIntensityFactor -= 1.0f;
            shipSpeed -= shipSlowDown;
        }
        shipSpeed = Mathf.Clamp(shipSpeed, 0.0f, 40.0f*shipBoost);
        body.velocity = body.transform.forward * shipSpeed;
    }

    private void HandleShipLights()
    {
        mainLight.intensity = Mathf.Clamp(lightIntensityFactor, 3.0f, maxIntensity);
        leftLight.intensity = Mathf.Clamp(lightIntensityFactor, 3.0f, maxIntensity);
        rightLight.intensity = Mathf.Clamp(lightIntensityFactor, 3.0f, maxIntensity);
    }
}