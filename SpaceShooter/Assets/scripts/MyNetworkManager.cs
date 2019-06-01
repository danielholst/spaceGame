using UnityEngine;
using UnityEngine.Networking;
public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        player.transform.LookAt(Vector3.zero);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    // Get random spawn position at boarder
    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3();
        float angle = Random.Range(0.0f, 2 * Mathf.PI);
        float radius = 400f;
        spawnPosition.x = Mathf.Sin(angle) * radius;
        spawnPosition.y = 0.0f;
        spawnPosition.z = Mathf.Cos(angle) * radius;

        Debug.Log("Spawn position = " + spawnPosition);
        return spawnPosition;
    }

}