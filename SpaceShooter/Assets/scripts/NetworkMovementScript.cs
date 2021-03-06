﻿using UnityEngine;
using UnityEngine.Networking;

/*
 * Movement Script for player ship in multiplayer game
 * Handles ship yaw, pitch, roll.
 * Thrust is handled in ShipThrustScript
 * 
 * Keyboard controls
 * W - Thrust
 * S - Break
 * A - turn left (yaw)
 * D - turn right (yaw)
 * Left arrow - roll left
 * Right arrow - roll right
 * Up arrow - tilt up
 * Down arrow - tilt down
 * Space - blaster trigger
 * Shift - speed boozt
 *
 * Hand controller
 * Left stick - thrust and turn (yaw)
 * Right stick - roll and pitch
 * Left bumper - speed boost
 * Right bumper - blaster trigger
 */

public class NetworkMovementScript : NetworkBehaviour
{
    private float stabilitySpeed;
    private float rollRate;
    private float pitchRate;
    private float yawRate;
    private float turningFactor;

    // Use this for initialization
    void Start()
    {
        stabilitySpeed = 1f;    // how fast the ship will regulate back to its stable position.
        rollRate = 100.0f;  // how fast the ship will turn around the forward axis (roll).
        pitchRate = 50.0f;  // how fast the ship will turn around the left axis (pitch).
        yawRate = 10.0f;    // how fast the ship will turn around the up axis (yaw).
        turningFactor = 1f;   // how much the roll will contribute to the turnSpeed.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        ShipYaw();

        ShipPitch();

        RegulateStableRotation();
    }

    // Yaw (turn) the ship with A and D keys.
    private void ShipYaw()
    {
        float angleAroundY = 0f;
        float angleAroundZ = 0f;
        float turningBoost = Mathf.Clamp(1f + Mathf.Abs(transform.eulerAngles.z * turningFactor), 1f, 5f);

        if (Input.GetKey(KeyCode.A))
        {
            float angleZ = transform.localEulerAngles.z;
            angleZ = (angleZ > 180) ? angleZ - 360 : angleZ;

            // Yaw left
            angleAroundY = Mathf.LerpAngle(transform.eulerAngles.y, transform.eulerAngles.y - 2f, Time.deltaTime * yawRate * turningBoost);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleAroundY, transform.eulerAngles.z);

            // Roll left
            if (Mathf.Abs(angleZ) < 50f)
            {
                angleAroundZ = Mathf.LerpAngle(transform.eulerAngles.z, transform.eulerAngles.z + 1.4f, Time.deltaTime * rollRate);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleAroundZ);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            float angleZ = transform.localEulerAngles.z;
            angleZ = (angleZ > 180) ? angleZ - 360 : angleZ;

            // Yaw right
            angleAroundY = Mathf.LerpAngle(transform.eulerAngles.y, transform.eulerAngles.y + 2f, Time.deltaTime * yawRate * turningBoost);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleAroundY, transform.eulerAngles.z);

            // Roll right
            if (Mathf.Abs(angleZ) < 50f)
            {
                angleAroundZ = Mathf.LerpAngle(transform.eulerAngles.z, transform.eulerAngles.z - 1.4f, Time.deltaTime * rollRate);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleAroundZ);
            }
        }
    }

    // Pitch ship with up and down keys
    private void ShipPitch()
    {
        float angleAroundX = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            float angleX = transform.localEulerAngles.x;
            angleX = (angleX > 180) ? angleX - 360 : angleX;
            // Pitch up
            if (Mathf.Abs(angleX) < 50f)
            {
                angleAroundX = Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x - 2f, Time.deltaTime * pitchRate);
                transform.eulerAngles = new Vector3(angleAroundX, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            float angleX = transform.localEulerAngles.x;
            angleX = (angleX > 180) ? angleX - 360 : angleX;
            // Pitch down
            if (Mathf.Abs(angleX) < 50f)
            {
                angleAroundX = Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x + 2f, Time.deltaTime * pitchRate);
                transform.eulerAngles = new Vector3(angleAroundX, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
    }

    // makes the ship stabilize roll and pitch.
    private void RegulateStableRotation()
    {
        float targetAngleX = Mathf.LerpAngle(transform.eulerAngles.x, 0f, Time.deltaTime * stabilitySpeed);
        float targetAngleZ = Mathf.LerpAngle(transform.eulerAngles.z, 0f, Time.deltaTime * stabilitySpeed);

        transform.eulerAngles = new Vector3(targetAngleX, transform.eulerAngles.y, targetAngleZ);
    }

    // init setup function for local player, TODO
    public override void OnStartLocalPlayer()
    {
        Debug.Log("set camera target");
        Camera.main.GetComponent<CameraFollowNetworkScript>().SetTarget(gameObject.transform);

        // setup color of ship based on which team local player is in
    }
}
