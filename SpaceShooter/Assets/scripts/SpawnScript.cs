using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

/*
 * Handle spawn of ship at start of game or when killed.
 */
public class SpawnScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ClientRpc]
    public void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // spawn at random position
            transform.position = GetRandomSpawnPosition();
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    // TODO check that spawn is not inside a asteroid or to close to any enemy ship?
    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3();
        float maxRadius = GetComponent<SpaceBoundarieScript>().getSpaceRadius();
        spawnPosition.x = Random.Range(-maxRadius / 2.0f, maxRadius / 2.0f);
        spawnPosition.y = Random.Range(-maxRadius / 10.0f, maxRadius / 10.0f); // not so much difference in elevation
        spawnPosition.z = Random.Range(-maxRadius / 2.0f, maxRadius / 2.0f);

        Debug.Log("Spawn position = " + spawnPosition);
        return spawnPosition;
    }
}
