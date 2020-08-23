using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public Text score;
    private int scoreVal = -100;


    private void Awake()
    { 
        instance = this;
        addScore();

    }

    public void addScore()
    {
        Debug.Log("Adding score");
        scoreVal = scoreVal + 100;
    }

    private void Update()
    {
        score.text = "SCORE " + scoreVal.ToString();
        //score.text = "TEST";
    }
}