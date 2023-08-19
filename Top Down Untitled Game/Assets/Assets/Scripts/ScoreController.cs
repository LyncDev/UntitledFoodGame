using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreController : MonoBehaviour
{
    public static int score;
    public static int unscore;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Unscore;
    void Start()
    {
        score = 0;
        unscore = 0;
    }

    private void Update()
    {
        Score.text = "Happy Customers: " + score;
        Unscore.text = "Unhappy Customers: " + unscore;
    }



    public static void scorecounter()
    {
        score++;
        Debug.Log("Score: " + score);
        
    }
    public static void unscorecounter()
    {
        unscore++;
        Debug.Log("Unscore: " + unscore);
    }
}
