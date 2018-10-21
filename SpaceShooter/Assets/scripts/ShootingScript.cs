using UnityEngine.Networking;
using UnityEngine;

// Script that handles the shooting for the player
// shoot with the Space key.
// Instantiates a laser beam gameObject

public class ShootingScript : NetworkBehaviour {

    public GameObject laserBeamObject;
    private Vector3 beamSpawnPosition;
    private float beamVelocity;

    // Use this for initialization
    void Start () {
        beamSpawnPosition = new Vector3(0.0f, -1.0f, 1.0f);
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
        var beam = Instantiate(laserBeamObject, transform.position + beamSpawnPosition, transform.rotation);

        // Add velocity to the bullet
        beam.GetComponent<Rigidbody>().velocity = beam.transform.forward * beamVelocity;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(beam);

        // Destroy the bullet after 4 seconds
        Destroy(beam, 4.0f);
    }
}
