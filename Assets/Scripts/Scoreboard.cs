using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private int score;
    public Text scoreText;


    

    public void AddScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }




}
