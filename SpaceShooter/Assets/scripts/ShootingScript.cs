using UnityEngine.Networking;
using UnityEngine;

// Script that handles the shooting for the player
// shoot with the Space key.
// Instantiates a laser beam gameObject

public class ShootingScript : NetworkBehaviour {

    public GameObject laserBeamObject;
    private Vector3 canonPosition;

	// Use this for initialization
	void Start () {
        canonPosition = new Vector3(0.0f, -1.0f, 1.0f);
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
            //instantate new projectile
            Instantiate(laserBeamObject, transform.position + canonPosition, transform.rotation);
        }
    }
}
