using System;
using UnityEngine;

// Script to handle the camera movement so it follows the ship
public class CameraFollowNetworkScript : MonoBehaviour
{
    private Transform shipTransform;
    private readonly float smoothing = 1.0f;

    private float distBehindShip;
    private Vector3 altitude;

    private void Start()
    {
        distBehindShip = 10f;
        altitude = new Vector3(0.0f, 4.0f, 0.0f);
    }

    private void LateUpdate()
    {
        // need to set this back to null when ship is destroyed. TODO
        if (shipTransform == null)
        {
            //if (GameObject.Find("Player(Clone)") != null)
            //{
            //    shipTransform = GameObject.Find("Player(Clone)").transform;
            //}
        }
        else
        {
            Vector3 targetCamPos = shipTransform.position + (-shipTransform.forward * distBehindShip) + altitude; // target.forward * distBehindShip;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing);
            transform.LookAt(shipTransform);
        }
    }

    public void SetTarget(Transform playerTransform)
    {
        shipTransform = playerTransform;
    }
}