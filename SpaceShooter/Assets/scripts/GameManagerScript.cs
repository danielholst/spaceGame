using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Game manager (single-player)
 * Here the time and score of the game is handled.
 * For a multiplayer game this is handled in the networkManager? 
 */
public class GameManagerScript : MonoBehaviour {

    private int numberOfPlayers;
    private float timer;

    // Use this for initialization
    void Start () {
        timer = 120.0f; // 2minutes
    }
 
    // Update is called once per frame
    void Update () {

        timer -= Time.deltaTime;

        // end of round
        if (timer < 0)
        {
            timer = 0;
            Debug.Log("End of round");
        }
    }

    public float getTime()
    {
        return timer;
    }
}