using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//This script will contain the high score data
public class HighScores 
{
    public string name;
    public string scorePos;
    public string rank;
    public float highScore;

    /*public HighScores(Player player)
    {
        name = player.doodlerName;
        scorePos = player.scorePos;
        rank = player.rank;
        highScore = player.currentScore;
    }*/
}
