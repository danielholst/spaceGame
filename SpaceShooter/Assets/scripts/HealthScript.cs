using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

/**
 * handles the health of the ship
 * respawn ship when reached zero
 **/

public class HealthScript : NetworkBehaviour
{
    private int health;
    private int maxHealth;

    // Use this for initialization
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Killed!");
            GetComponent<SpawnScript>().RpcRespawn();
            health = maxHealth;

        }
    }

    //decreases health of tank
    public void DecreaseHealth()
    {
        health -= 40;
    }
}