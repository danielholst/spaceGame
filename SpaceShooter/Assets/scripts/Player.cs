using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player class holds the information about the player.
 * Player name.
 * Player ID is assigned at start of multiplayer game.
 */
public class Player : MonoBehaviour {

    private string playerName;
    private int roundScore;
    private int kills;
    private int deaths;
    private int allTimeScore;
    private int id;

    void Start()
    {
        playerName = "Arnold";
        roundScore = 0;
        kills = 0;
        deaths = 0;
        allTimeScore = 0; // store in some way maybe
        id = 1; // should be set at network game start TODO
    }

    void SetPlayerName()
    {
        // get name from user input at first start or something. TODO
    }

    void IncreaseScore()
    {
        roundScore++;
        kills++;
        allTimeScore++;
    }

    void DecreaseScore()
    {
        roundScore--;
        deaths++;
        allTimeScore--;
    }

    string GetName()
    {
        return playerName;
    }

    int GetScore()
    {
        return roundScore;
    }

    int GetKills()
    {
        return kills;
    }

    int GetDeaths()
    {
        return deaths;
    }

    int GetAllTimeScore()
    {
        return allTimeScore;
    }

    int GetID()
    {
        return id;
    }

    void ResetScore()
    {
        roundScore = 0;
        deaths = 0;
        kills = 0;
    }
}
