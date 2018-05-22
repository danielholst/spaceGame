using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Script that handles the Gui timer
public class GuiTimerScript : MonoBehaviour
{
    GameObject gameManager;
    private int time;
    private Text text;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        text = GetComponent<Text>();
        time = 0;
    }

    // Update is called once per frame
    void OnGUI()
    {
        time = Mathf.RoundToInt(gameManager.GetComponent<GameManagerScript>().getTime());
        text.text = time.ToString();
    }
}