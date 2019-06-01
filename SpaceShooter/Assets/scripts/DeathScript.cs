using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeathScript : NetworkBehaviour
{

    public GameObject explosion1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		    
	}

    public void OnHit() {

        StartCoroutine(DelayExplosion());
        Debug.Log("Player killed");
        
    }

    private IEnumerator DelayExplosion() {
        // wait 1 sec then create explosion and remove player object
        yield return new WaitForSeconds(1f);
        Debug.Log("Player exploded");
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
