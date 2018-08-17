using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the space boundaries for each ship.
 * If a ship flies outside the boundary a warning will appear.
 * A timer will also start and if the ship does not return
 * inside the boundary during that time the ship will be destroyed.
 */

public class SpaceBoundarieScript : MonoBehaviour {

    public float warningTimer;
    public Vector3 shipPosition;
    public float shipDistance;
    public float maxDistance; // public for test
    private bool outsideBoundaries;

	// Use this for initialization
	void Start () {
        warningTimer = 5.0f;
        maxDistance = 20.0f;
        outsideBoundaries = false;
    }
	
	// Update is called once per frame
	void Update () {

        HandleBoundaries();
        if (outsideBoundaries)
        {
            HandleWarningTimer();
        }
    }

    private void HandleBoundaries()
    {
        shipPosition = this.gameObject.transform.position;
        shipDistance = Vector3.Magnitude(shipPosition); // expect (0,0,0) to be center of map

        if (shipDistance > maxDistance)
        {
            if (!outsideBoundaries)
            {
                outsideBoundaries = true;
                ShowWarning(true);
            }
        }
        else
        {
            if (outsideBoundaries)
            {
                outsideBoundaries = false;
                ShowWarning(false);
                warningTimer = 5.0f;
            }
        }
    }

    private void HandleWarningTimer()
    {
        warningTimer -= Time.deltaTime;

        if (warningTimer < 0)
        {
            warningTimer = 5.0f;
            // respawn logic? TODO
            Debug.Log("Ship destroyed!");
        }
    }

    // show the player a warning for leaving the space boundaries.
    private void ShowWarning(bool show)
    {
        // TODO this should call some canvas function that makes the edges
        // of the screen red or something like that.
        if (show)
        {
            Debug.Log("Outside boundaries!");
        }
        else
        {
            Debug.Log("Not outside boundaries!");
        }
    }
}
