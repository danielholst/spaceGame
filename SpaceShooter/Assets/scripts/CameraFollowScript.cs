using System;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform shipTransform;
    private readonly float smoothing = 2f;

    private float distBehindShip;
    private Vector3 altitude;
    //private Rigidbody cameraBody;
    //private Vector3 offset;

    private void Start()
    {
        distBehindShip = 10f;
        altitude = new Vector3(0.0f, 2.0f, 0.0f);
        //offset = transform.position - shipTransform.position;
        //cameraBody = GetComponent<Rigidbody>();
        //This locks the RigidBody so that it does not move or rotate in the Z axis.
        //cameraBody.constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        // calc on this .. not correct. Need to follow behind the ship with a certain distance.
        Vector3 targetCamPos = shipTransform.position + (-shipTransform.forward * distBehindShip) + altitude; // target.forward * distBehindShip;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.LookAt(shipTransform);
    }
}