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

    // Get random spawn position at boarder
    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3();
        float angle = Random.Range(0.0f, 2 * Mathf.PI);
        float radius = GetComponent<SpaceBoundarieScript>().GetSpaceRadius();
        spawnPosition.x = Mathf.Sin(angle)* radius;
        spawnPosition.y = 0.0f;
        spawnPosition.z = Mathf.Cos(angle) * radius;

        Debug.Log("Spawn position = " + spawnPosition);
        return spawnPosition;
    }
}
