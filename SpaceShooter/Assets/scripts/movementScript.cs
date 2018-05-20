using UnityEngine;

/*
 * Movement Script for player ship
 * Handles ship yaw, pitch, roll and thrust.
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
 * Left stick - thrust and turn
 * Right stick - roll and pitch
 * Left bumper - speed boost
 * Right bumper - blaster trigger
 */

public class MovementScript : MonoBehaviour
{
    public Rigidbody body;
    private float rollRate;
    private float pitchRate;
    private float yawRate;

    // Use this for initialization
    void Start()
    {
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
        if (Input.GetKey("left"))
        {
            // Roll left
            transform.Rotate(transform.forward  * rollRate * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            // Roll right
            transform.Rotate(transform.forward * -rollRate * Time.deltaTime);
        }
    }

    // Pitch ship with up and down keys
    private void ShipPitch()
    {
        if (Input.GetKey("up"))
        {
            // Pitch up
            transform.Rotate(transform.right * (-pitchRate) * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            // Pitch down
            transform.Rotate(transform.right * pitchRate * Time.deltaTime);
        }
    }
}