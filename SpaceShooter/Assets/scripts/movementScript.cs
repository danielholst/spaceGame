using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {

	private Vector3 rotationVecSideways;
	private Vector3 rotationVecUp;
	private Vector3 forceVecForward;
	public Rigidbody body;
	public GameObject EventHandler;

	// Use this for initialization
	void Start () {
		rotationVecSideways = new Vector3 (10f, 0f, 0f);
		rotationVecUp = new Vector3 (0f, 10f, 0f);
		forceVecForward = new Vector3 (0f, 0f, 40f);
	}

	// Update is called once per frame
	void Update () {

		//if (EventHandler.GetComponent<holdTime> ().startGame) {

		if (Input.GetKey (KeyCode.W)) {
			body.AddForce (body.transform.forward * 10f);
		} else if ( Input.GetKey (KeyCode.S)) {
			body.AddForce (- body.transform.forward * 10f);
		} else {
			body.velocity = body.velocity - 0.1f * body.velocity;
		}
		
		if (Input.GetKey ("up")) {
			// rotate up
			Quaternion deltaRotation = Quaternion.Euler(-body.transform.right * 30f * Time.deltaTime);
			body.MoveRotation(body.rotation * deltaRotation);
		}
		if (Input.GetKey ("down")) {
			// rotate down
			Quaternion deltaRotation = Quaternion.Euler(body.transform.right * 30f * Time.deltaTime);
			body.MoveRotation(body.rotation * deltaRotation);
		}
		if (Input.GetKey ("left")) {
			// rotate left
			Quaternion deltaRotation = Quaternion.Euler(-body.transform.up * 30f * Time.deltaTime);
			body.MoveRotation(body.rotation * deltaRotation);
		}
		if (Input.GetKey ("right")) {
			// rotate right
			Quaternion deltaRotation = Quaternion.Euler(body.transform.up * 30f * Time.deltaTime);
			body.MoveRotation(body.rotation * deltaRotation);
		}
	}

}
