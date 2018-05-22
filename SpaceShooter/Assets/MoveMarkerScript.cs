using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that handles the position of the marker in the main menu
public class MoveMarkerScript : MonoBehaviour {

    public Vector3 markerPos; // position of marker to the left of the mode
    public int mode;

    // Use this for initialization
    void Start () {
        markerPos = new Vector3(-150, -50, 0);
        mode = 0;
    }

    // Update is called once per frame
    void Update () {

        mode = GameObject.Find("UserInput").GetComponent<HandleMainMenuInputScript>().GetMode();

        if (mode == 0)
        {
            markerPos.x = -150;
            markerPos.y = -50;
        }
        else if (mode == 1)
        {
            markerPos.x = -130;
            markerPos.y = -100;
        }
        else // mode == 2
        {
            markerPos.x = -100;
            markerPos.y = -150;
        }

        GetComponent<RectTransform>().anchoredPosition = markerPos;
    }
}
