using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/**
 * handles the collision for players projectiles
 **/
public class ProjectileCollisionScript : NetworkBehaviour
{
    private int playerID;
    public GameObject explosion1;
    // private GameObject player;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("HIT!");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<HealthScript>().DecreaseHealth();
        }
        CmdExplode();
    }

    [Command]
    void CmdExplode()
    {
        var explosion = Instantiate(explosion1, transform.position, transform.rotation);
        NetworkServer.Spawn(explosion);
        Destroy(gameObject);
    }
}