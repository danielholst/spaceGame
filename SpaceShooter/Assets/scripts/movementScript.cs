using UnityEngine;

/*
 * Movement Script for player ship
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

public class MovementScript : MonoBehaviour
{
    private float stabilitySpeed;
    private float rollRate;
    private float pitchRate;
    private float yawRate;

    // Use this for initialization
    void Start()
    {
        stabilitySpeed = 2f;
        rollRate = 100.0f;
        pitchRate = 50.0f;
        yawRate = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ShipYaw();

        ShipRoll();

        ShipPitch();

        RegulateStableRotation();
    }

    // Yaw (turn) the ship with A and D keys.
    private void ShipYaw()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Yaw left
            transform.Rotate(transform.up * (-yawRate) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Yaw right
            transform.Rotate(transform.up * yawRate * Time.deltaTime);
        }
    }

    // Roll ship with left and right keys.
    private void ShipRoll()
    {
        float angleAroundZ = 0f;

        if (Input.GetKey("left"))
        {
            // Roll left
            angleAroundZ = Mathf.LerpAngle(transform.eulerAngles.z, transform.eulerAngles.z + 1f, Time.deltaTime * rollRate);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleAroundZ);
        }
        if (Input.GetKey("right"))
        {
            // Roll right
            angleAroundZ = Mathf.LerpAngle(transform.eulerAngles.z, transform.eulerAngles.z - 1f, Time.deltaTime * rollRate);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angleAroundZ);
        }
    }

    // Pitch ship with up and down keys
    private void ShipPitch()
    {
        float angleAroundX = 0f;
        if (Input.GetKey("up"))
        {
            // Pitch up
            angleAroundX = Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x - 1f, Time.deltaTime * pitchRate);
            transform.eulerAngles = new Vector3(angleAroundX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (Input.GetKey("down"))
        {
            // Pitch down
            angleAroundX = Mathf.LerpAngle(transform.eulerAngles.x, transform.eulerAngles.x + 1f, Time.deltaTime * pitchRate);
            transform.eulerAngles = new Vector3(angleAroundX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    // makes the ship stabilize roll and pitch.
    private void RegulateStableRotation()
    {
        float targetAngleX = Mathf.LerpAngle(transform.eulerAngles.x, 0f, Time.deltaTime * stabilitySpeed);
        float targetAngleZ = Mathf.LerpAngle(transform.eulerAngles.z, 0f, Time.deltaTime * stabilitySpeed);

        transform.eulerAngles = new Vector3(targetAngleX, transform.eulerAngles.y, targetAngleZ);
    }
}