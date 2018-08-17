﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/**
 * handles the collision for players projectiles
 **/
public class ProjectileCollisionScript : NetworkBehaviour
{
    private int playerID;
    public GameObject explosion1;
    private GameObject player;
    private GameObject exp1;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT!");
            exp1 = Instantiate(explosion1, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }
}