using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// handle the input from the user to enter either
// single or multiplayer mode.
public class HandleMainMenuInputScript : MonoBehaviour {

    public int mode; // 0 = singleplayer, 1 = multiplayer, 2 = options
	// Use this for initialization
	void Start () {
        mode = 0;
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (mode != 0)
            {
                mode -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (mode != 2)
            {
                mode += 1;
            }
        }

        // enter mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mode == 0)
            {
                Debug.Log("Start single player mode");
                SceneManager.LoadScene(1);
            }
            if (mode == 1)
            {
                Debug.Log("Start multiplayer mode");
            }
            if (mode == 2)
            {
                Debug.Log("Open options");
            }
        }
    }
}