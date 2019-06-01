using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DeathScript : NetworkBehaviour
{
    public GameObject playerPrefab;
    public GameObject explosion1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		    
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("HIT!");
        if (other.gameObject.tag == "asteroid")
        {
            CmdExplode();
            OnHit();
        }
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
        yield return new WaitForSeconds(1f);
        CmdRespawnSvr();
    }

    [Command]
    void CmdExplode()
    {
        var explosion = Instantiate(explosion1, transform.position, transform.rotation);
        NetworkServer.Spawn(explosion);
        //StartCoroutine(Respawn());
    }

    [Command]
    void CmdRespawnSvr()
    {
        Debug.Log("RESPAWWWWWN");
        var spawn = GameObject.FindWithTag("networkManager").GetComponent<MyNetworkManager>().GetRandomSpawnPosition();
        var newPlayer = (GameObject)Instantiate(playerPrefab, spawn, Quaternion.identity);
        newPlayer.transform.LookAt(Vector3.zero);
        NetworkServer.Destroy(this.gameObject);
        NetworkServer.ReplacePlayerForConnection(this.connectionToClient, newPlayer, this.playerControllerId);

    }

    private IEnumerator Respawn()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Debug.Log("respawn");
        this.gameObject.SetActive(true);
        //GetComponent<MeshRenderer>().enabled = true;
    }
}
