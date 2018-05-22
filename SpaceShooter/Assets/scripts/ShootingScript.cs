using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that handles the shooting for the player
// shoot with the Space key.
// Instantiates a laser beam gameObject

public class ShootingScript : MonoBehaviour {

    public GameObject laserBeamObject;
    private Vector3 canonPosition;

	// Use this for initialization
	void Start () {
        canonPosition = new Vector3(0.0f, -0.5f, 1.0f);
	}

    // Update is called once per frame
    void Update()
    {
        // shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instantate new projectile
            Instantiate(laserBeamObject, transform.position + canonPosition, transform.rotation);
        }
    }
}
