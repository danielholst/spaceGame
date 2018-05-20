using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that handles the movement of the laser beam
public class LaserBeamMovementScript : MonoBehaviour {

    private Vector3 beamDirection;
    private float beamSpeed;
    private float timer;

	// Use this for initialization
	void Start () {
        beamDirection = transform.forward;
        beamSpeed = 20.0f;
        timer = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += beamDirection * beamSpeed * Time.deltaTime;
        timer -= Time.deltaTime;

        // destroy projectile after 3 seconds
        if (timer < 0.0f)
        {
            Destroy(gameObject);
        }
	}
}
