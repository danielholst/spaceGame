using System;
using UnityEngine;

// Script to handle the camera movement so it follows the ship
public class CameraFollowNetworkScript : MonoBehaviour
{
    private Transform shipTransform;
    private float smoothing;
    private float distBehindShip;
    private Vector3 offset;

    private void Start()
    {
        smoothing = 0.2f;
        distBehindShip = -10;
        offset = new Vector3(0.0f, 3.0f, -1.0f);
    }

    private void FixedUpdate()
    {
        // need to set this back to null when ship is destroyed. TODO
        if (shipTransform == null)
        {
        }
        else
        {
            Vector3 desiredPosition = shipTransform.position + offset + shipTransform.forward * distBehindShip;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
            transform.position = smoothedPosition;
            transform.LookAt(shipTransform);
        }
    }

    public void SetTarget(Transform playerTransform)
    {
        shipTransform = playerTransform;
    }
}