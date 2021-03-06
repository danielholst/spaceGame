﻿using System;
using UnityEngine;

// Script to handle the camera movement so it follows the ship
public class CameraFollowScript : MonoBehaviour
{
    public Transform shipTransform;
    private readonly float smoothing = 10f;

    private float distBehindShip;
    private Vector3 altitude;

    private void Start()
    {
        distBehindShip = 10f;
        altitude = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void LateUpdate()
    {
        Vector3 targetCamPos = shipTransform.position + (-shipTransform.forward * distBehindShip) + altitude; // target.forward * distBehindShip;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        transform.LookAt(shipTransform);
    }
}