using UnityEngine.Networking;
using UnityEngine;

/*
 * This script handles the environment and 
 * spawns asteroids and stuff in the space.
 */
public class EnvironmentScript : NetworkBehaviour {

    // spawnable objects
    public GameObject bigAsteroid;
    public GameObject mediumAsteroid;
    public GameObject smallAsteroid;
    private readonly int numberOfBigAsteroids = 40;
    private readonly int numberOfMediumAsteroids = 60;
    private readonly int numberOfSmallAsteroids = 100;
    private readonly float minAsteroidSpeed = 1.0f;
    private readonly float maxAsteroidSpeed = 10.0f;
    private readonly float spaceLimit = 400.0f;

    public override void OnStartServer()
    {
        SpawnAsteroids();
    }
    // Use this for initialization
    void SpawnAsteroids () {

        // spawn asteroids at random in the space
        for (int i = 0; i < numberOfBigAsteroids; i++)
        {
            //instantate new big asteroid
            var asteroid = Instantiate(bigAsteroid, GetRandomSpawnPosition(), Quaternion.identity);
            asteroid.GetComponent<Rigidbody>().velocity = Vector3.Normalize(GetRandomDirection()) * GetRandomSpeed();
            NetworkServer.Spawn(asteroid);
        }
        for (int i = 0; i < numberOfMediumAsteroids; i++)
        {
            //instantate new big asteroid
            var asteroid = Instantiate(mediumAsteroid, GetRandomSpawnPosition(), Quaternion.identity);
            asteroid.GetComponent<Rigidbody>().velocity = Vector3.Normalize(GetRandomDirection()) * GetRandomSpeed();
            NetworkServer.Spawn(asteroid);
        }
        for (int i = 0; i < numberOfSmallAsteroids; i++)
        {
            //instantate new small asteroid
            var asteroid = Instantiate(smallAsteroid, GetRandomSpawnPosition(), Quaternion.identity);
            asteroid.GetComponent<Rigidbody>().velocity = Vector3.Normalize(GetRandomDirection()) * GetRandomSpeed();
            NetworkServer.Spawn(asteroid);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3
        {
            x = Random.Range(-spaceLimit, spaceLimit),
            y = Random.Range(-spaceLimit, spaceLimit),
            z = Random.Range(-spaceLimit, spaceLimit)
        };

        return spawnPosition;
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = new Vector3
        {
            x = Random.Range(-1.0f, 1.0f),
            y = Random.Range(-1.0f, 1.0f),
            z = Random.Range(-1.0f, 1.0f)
        };

        return direction;
    }

    private float GetRandomSpeed()
    {
        return Random.Range(minAsteroidSpeed, maxAsteroidSpeed);
    }
}
