using UnityEngine.Networking;
using UnityEngine;

// Script that handles the shooting for the player
// shoot with the Space key.
// Instantiates a laser beam gameObject

public class ShootingScript : NetworkBehaviour {

    public GameObject laserBeamObject;
    private float beamVelocity;

    // Use this for initialization
    void Start () {
        beamVelocity = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        // shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }

    [Command]
    private void CmdFire()
    {
        //instantate new projectile
        var beam = Instantiate(laserBeamObject, transform.position + (transform.forward * 5) + (transform.up * -2), transform.rotation);

        // Add velocity to the bullet
        beam.GetComponent<Rigidbody>().velocity = beam.transform.forward * beamVelocity;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(beam);

        // Destroy the bullet after 4 seconds
        Destroy(beam, 4.0f);
    }
}
