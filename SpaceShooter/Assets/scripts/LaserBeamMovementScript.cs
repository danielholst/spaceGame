using UnityEngine.Networking;
using UnityEngine;

// Script that handles the movement of the laser beam
public class LaserBeamMovementScript : NetworkBehaviour {

    private Vector3 beamDirection;
    private float beamSpeed;
    private float lifeTime;

	// Use this for initialization
	void Start () {
        beamDirection = transform.forward;
        beamSpeed = 30.0f;
        lifeTime = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += beamDirection * beamSpeed * Time.deltaTime;

        // destroy projectile after timer
        Destroy(gameObject, lifeTime);
        
	}
}
